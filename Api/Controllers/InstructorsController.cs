using Application.Instructors.Commands.AddInstructor;
using Application.Instructors.Commands.DeleteInstructor;
using Application.Instructors.Commands.UpdateInstructor;
using Application.Instructors.Queries.GetInstructorsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class InstructorsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<InstructorListVm>> GetAll([FromQuery] GetInstructorsListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add(AddInstructorCommand command)
        {
            int id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id ,UpdateInstructorCommand command)
        {
            command.InstructorId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteInstructorCommand { InstructorId = id });
            return NoContent();
        }
        
    }
}
