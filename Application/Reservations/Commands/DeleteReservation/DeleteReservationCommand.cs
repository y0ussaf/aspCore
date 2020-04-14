using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.Commands.DeleteReservation
{
   public class DeleteReservationCommand : IRequest
    {
        public int ReservationId { get; set; }
    }
}
