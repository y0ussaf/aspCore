using Application.Rooms.Commands.AddRoom;
using Application.Rooms.Commands.DeleteRoom;
using Application.Rooms.Commands.UpdateRoom;
using Application.Rooms.Queries.GetRoomsList;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class RoomsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<RoomListVm>> GetAll([FromQuery] GetRoomsQuery query )
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add(AddRoomCommand command)
        {
            int id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id,UpdateRoomCommand command)
        {
            command.RoomId = id;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomCommand { RoomId = id });
            return NoContent();
        }
    }
}
