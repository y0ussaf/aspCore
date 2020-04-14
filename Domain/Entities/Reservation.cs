using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
     public class Reservation
    {
        public int ReservationId { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public Room Room { get; set; }
        public DateTimeRange DateTimeRange { get; set; }
    }
}
