using System.Collections.Generic;
using Application.Courses.Queries.GetCoursesList;
using Application.Instructors.Queries.GetInstructorsList;
using Application.Reservations.Queries.GetReservationsList;
using Application.Rooms.Queries.GetRoomsList;

namespace WebApplication1.Models
{
    public class ReservationCreateModel
    {
        public List<CourseDto> Courses { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public List<InstructorDto> Instructors { get; set; }
        public ReservationDto Reservation { get; set; }
    }
}