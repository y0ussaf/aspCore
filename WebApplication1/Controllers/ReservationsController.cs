using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCoursesList;
using Application.Instructors.Queries.GetInstructorsList;
using Application.Reservations.Commands.ReserveRoom;
using Application.Reservations.Queries.GetReservationsList;
using Application.Rooms.Queries.GetRoomsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]

    public class ReservationsController : Controller
    {
        private readonly IConfiguration _configuration;
        public ReservationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET
        public async Task<ActionResult> Index()
        {
            ReservationsListVm reservationsList = new ReservationsListVm();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/reservations/GetAll");
                string apiResponse = await response.Content.ReadAsStringAsync();
                reservationsList = JsonConvert.DeserializeObject<ReservationsListVm>(apiResponse);
            }

            return View(reservationsList);
        }
        public async Task<ActionResult> Create()
        {
            List<CourseDto> courses;
            List<InstructorDto> instructors;
            List<RoomDto> rooms;
            RoomListVm roomsList;
            InstructorListVm instructorsList;
            CoursesListVm coursesList;
            using (var httpClient = new HttpClient())
            {
                using var res1 = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/courses/GetAll");
                string apiResponse = await res1.Content.ReadAsStringAsync();
                coursesList = JsonConvert.DeserializeObject<CoursesListVm>(apiResponse);
                courses = coursesList.Courses;
                using var res2 = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/rooms/GetAll");
                apiResponse = await res2.Content.ReadAsStringAsync();
                roomsList = JsonConvert.DeserializeObject<RoomListVm>(apiResponse);
                rooms = roomsList.Rooms;
                using var res3 = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/instructors/GetAll");
                apiResponse = await res3.Content.ReadAsStringAsync();
                instructorsList = JsonConvert.DeserializeObject<InstructorListVm>(apiResponse);
                instructors = instructorsList.Instructors;
            }

            ReservationCreateModel model = new ReservationCreateModel()
            {
                Reservation = new ReservationDto(),
                Courses = courses,
                Rooms = rooms,
                Instructors = instructors
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReserveRoomCommand reserveRoom)
        {
            var ok = false;
            using (var httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(reserveRoom);
                HttpContent content = new StringContent(json,System.Text.Encoding.UTF8, 
                    "application/json");
                using var response = await httpClient.PostAsync(_configuration.GetSection("apiUrl").Value+"/reservations/Add",content);
               var  apiResponse = await response.Content.ReadAsStringAsync();
               Console.WriteLine("res "+apiResponse);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ok = true;
                }
            }
            return RedirectToAction("");
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            
            using (var httpClient = new HttpClient())
            {
                var t = $"{_configuration.GetSection("apiUrl").Value}/reservations/delete/{id}";

                using var response = await httpClient.DeleteAsync(t);
                await response.Content.ReadAsStringAsync();
                
            }

            return RedirectToAction(nameof(Index));
         
        }
    }
}