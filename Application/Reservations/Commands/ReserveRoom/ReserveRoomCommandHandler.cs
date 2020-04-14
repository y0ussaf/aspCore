using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Reservations.Commands.ReserveRoom
{
    class ReserveRoomCommandHandler : IRequestHandler<ReserveRoomCommand,int>
    {
        private readonly IRepository _context;

        public ReserveRoomCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
        {
            var instructorId = request.InstructorId;
            var instructor =await _context.Instructors.FindAsync(instructorId);
            var roomId = request.RoomId;
            var room = await _context.Rooms.Where(r => r.RoomId == roomId).Include(r => r.Reservations).FirstOrDefaultAsync();
            var courseId = request.CourseId;
            var course = await _context.Courses.FindAsync(courseId);
            if (instructor == null || course == null || room == null)
            {
                throw new BadRequestException("invalid informations");
            }
            var reservation = new Reservation();          
            // domain rules;
            try
            {
                var dateTitmeRange = new DateTimeRange(request.Start, request.End);
                reservation.DateTimeRange = dateTitmeRange;
                reservation.Course = course;
                reservation.Instructor = instructor;
                reservation.Room = room;
                room.AddReservation(reservation);

            }
            catch (Exception  e) when (e is InvalidDateTimeRange || e is FailureReservingRoom)
            {
                throw new BadRequestException(e.Message);
            }
             await _context.SaveChangesAsync(cancellationToken);
            return reservation.ReservationId;

        }
    }
}
