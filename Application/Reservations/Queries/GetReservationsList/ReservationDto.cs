using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.Queries.GetReservationsList
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string InstructorName { get; set; }
        public string CourseName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
