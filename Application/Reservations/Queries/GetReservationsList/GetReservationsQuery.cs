using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Application.Reservations.Queries.GetReservationsList
{
    public class GetReservationsQuery : IRequest<ReservationsListVm>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? RoomId { get; set; }
        public int? InstructorId { get; set; }
        public int? CourseId { get; set; }
    }
}
