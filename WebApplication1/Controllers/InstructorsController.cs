using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourse;
using Application.Courses.Queries.GetCoursesList;
using Application.Instructors.Commands.AddInstructor;
using Application.Instructors.Queries.GetInstructorsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IConfiguration _configuration;
        public InstructorsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            InstructorListVm instructorList = new InstructorListVm();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetSection("apiUrl").Value+"/instructors/GetAll");
                string apiResponse = await response.Content.ReadAsStringAsync();
                instructorList = JsonConvert.DeserializeObject<InstructorListVm>(apiResponse);
            }

            return View(instructorList);
        }

        

        // GET: Courses/Create
        public  ActionResult Create()
        {
            AddInstructorCommand instructor = new AddInstructorCommand();
            return View(instructor);
        }

        // POST: Courses/Create
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddInstructorCommand addInstructorCommand)
        {
            var ok = false;
            using (var httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(addInstructorCommand);
                HttpContent content = new StringContent(json,System.Text.Encoding.UTF8, 
                    "application/json");
                Console.WriteLine("json " +json);
                using var response = await httpClient.PostAsync(_configuration.GetSection("apiUrl").Value+"/instructors/Add",content);
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
                var t = $"{_configuration.GetSection("apiUrl").Value}/instructors/delete/{id}";

                using var response = await httpClient.DeleteAsync(t);
                var a = await response.Content.ReadAsStringAsync();
                Console.WriteLine("yyy"+a+response.StatusCode);
            }

            return RedirectToAction(nameof(Index));
         
        }
    }
}