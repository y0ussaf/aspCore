using Application.Courses.Commands.AddCourse;
using Application.Courses.Commands.DeleteCourse;
using Application.Courses.Commands.UpdateCourse;
using Application.Courses.Queries.GetCoursesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{ 
    public class CoursesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CoursesListVm>> GetAll([FromQuery] GetCoursesListQuery query)
        {

            return Ok(await Mediator.Send(query));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add(AddCourseCommand command)
        {
            int id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id ,UpdateCourseCommand command)
        {
            command.CourseId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCourseCommand { CourseId = id });
            return NoContent();
        }
    }
}
