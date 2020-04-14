using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Reservations.Queries.GetReservationsList
{

    class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, ReservationsListVm>
    {
        private readonly IRepository _context;

        public GetReservationsQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<ReservationsListVm> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Reservations.AsQueryable();
            if(request.RoomId != null)
            {
                query = query.Where(r => r.RoomId == request.RoomId);
            }
            if(request.InstructorId != null)
            {
                query = query.Where(r => r.InstructorId == request.InstructorId);
            }
            if (request.CourseId != null)
            {
                query = query.Where(r => r.CourseId == request.CourseId);
            }
            var count = await query.CountAsync(cancellationToken: cancellationToken);
            var result =  _context.Reservations.Include(r => r.Instructor).Include(r => r.Course)
                .Include(r => r.Room)
                .Paginate( request.PageSize, request.Page)
                .Select(r =>
                new ReservationDto() { CourseName = r.Course.Name, 
                    InstructorName = r.Instructor.Name,
                    Start = r.DateTimeRange.Start,
                    End = r.DateTimeRange.End,
                    RoomName = r.Room.Name,
                    Id = r.ReservationId
                }
            );
            var reservationsDtos =await Task.FromResult(result.ToList());
            ReservationsListVm listVm = new ReservationsListVm(reservationsDtos, count, request.Page, request.PageSize);
            return listVm;

        }
    }
}
