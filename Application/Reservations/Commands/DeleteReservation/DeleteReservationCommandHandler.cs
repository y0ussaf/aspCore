using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.DeleteReservation
{
   
    class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IRepository _context;

        public DeleteReservationCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses
                 .FindAsync(request.ReservationId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reservation), request.ReservationId);
            }
            _context.Courses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
