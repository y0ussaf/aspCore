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

namespace Application.Reservations.Commands.UpdateReservation
{
    class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository _context;
        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation =await _context.Reservations.Where(r => r.ReservationId.Equals(request.ReservationId)).FirstOrDefaultAsync();
            if(reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), request.ReservationId);
            }
            var room = await _context.Rooms.Where(r => r.RoomId.Equals(reservation.RoomId)).Include(r => r.Reservations).FirstOrDefaultAsync();
            try
            {
                var dateTimeRange = new DateTimeRange(request.Start, request.End);
                room.ChangeReservationDate(reservation.ReservationId,dateTimeRange);
            }catch(Exception e) when (e is FailureReservingRoom || e is InvalidDateTimeRange)
            {
                throw new BadRequestException(e.Message);
            }
            return Unit.Value;
        }
    }
}
