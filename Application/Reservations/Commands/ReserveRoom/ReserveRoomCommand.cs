using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.Commands.ReserveRoom
{
   public class ReserveRoomCommand : IRequest<int>
    {
        public int RoomId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
