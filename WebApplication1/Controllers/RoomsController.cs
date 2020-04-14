using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Instructors.Commands.AddInstructor;
using Application.Instructors.Queries.GetInstructorsList;
using Application.Rooms.Commands.AddRoom;
using Application.Rooms.Queries.GetRoomsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IConfiguration _configuration;
        public RoomsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            RoomListVm roomListVm = new RoomListVm();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/rooms/GetAll");
                string apiResponse = await response.Content.ReadAsStringAsync();
                roomListVm = JsonConvert.DeserializeObject<RoomListVm>(apiResponse);
            }

            return View(roomListVm);
        }

        

        // GET: Courses/Create
        public  ActionResult Create()
        {
            AddRoomCommand room = new AddRoomCommand();
            return View(room);
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddRoomCommand addRoomCommand)
        {
            var ok = false;
            using (var httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(addRoomCommand);
                HttpContent content = new StringContent(json,System.Text.Encoding.UTF8, 
                    "application/json");
                Console.WriteLine("json " +json);
                using var response = await httpClient.PostAsync(_configuration.GetSection("apiUrl").Value+"/rooms/Add",content);
                Console.WriteLine( await response.Content.ReadAsStringAsync());
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
                var t = $"{_configuration.GetSection("apiUrl").Value}/rooms/delete/{id}";

                using var response = await httpClient.DeleteAsync(t);
                await response.Content.ReadAsStringAsync();
                
            }

            return RedirectToAction(nameof(Index));
         
        }
    }
}