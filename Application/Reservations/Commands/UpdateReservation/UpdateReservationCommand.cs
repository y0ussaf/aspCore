using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
