using Application.Reservations.Commands.DeleteReservation;
using Application.Reservations.Commands.ReserveRoom;
using Application.Reservations.Commands.UpdateReservation;
using Application.Reservations.Queries.GetReservationsList;
using Application.Rooms.Queries.GetRoomsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class ReservationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ReservationsListVm>> GetAll([FromQuery] GetReservationsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add(ReserveRoomCommand command)
        {
            int id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id ,UpdateReservationCommand command)
        {
            command.ReservationId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteReservationCommand { ReservationId = id });
            return NoContent();
        }
    }
}
