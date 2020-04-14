using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourse;
using Application.Courses.Queries.GetCoursesList;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IConfiguration _configuration;
        public CoursesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            CoursesListVm coursesList = new CoursesListVm();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/courses/GetAll");
                string apiResponse = await response.Content.ReadAsStringAsync();
                coursesList = JsonConvert.DeserializeObject<CoursesListVm>(apiResponse);
            }

            return View(coursesList);
        }

        

        // GET: Courses/Create
        public  ActionResult Create()
        {
            AddCourseCommand course = new AddCourseCommand();
            return View(course);
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCourseCommand addCourseCommand)
        {
            var ok = false;
            using (var httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(addCourseCommand);
                HttpContent content = new StringContent(json,System.Text.Encoding.UTF8, 
                    "application/json");
                Console.WriteLine("json " +json);
                using var response = await httpClient.PostAsync(_configuration.GetSection("apiUrl").Value+"/courses/Add",content);
                Console.WriteLine( await response.Content.ReadAsStringAsync());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ok = true;
                }
            }
            return RedirectToAction("");
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

         

        // POST: Courses/Delete/5
        [HttpPost]

        public async Task<ActionResult> Delete(int id)
        {
                using (var httpClient = new HttpClient())
                {
                    var t = $"{_configuration.GetSection("apiUrl").Value}/courses/delete/{id}";
                    using var response = await httpClient.DeleteAsync(t);
                    var r = await response.Content.ReadAsStringAsync();
                }

                return RedirectToAction(nameof(Index));
         
        }
    }
}