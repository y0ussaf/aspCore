using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Rooms.Commands.DeleteRoom
{
    class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IRepository _context;

        public DeleteRoomCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                 .FindAsync(request.RoomId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }
            if (entity.Reservations.Any())
            {
                throw new BadRequestException("this room has resevervations associated with it delete them first");
            }
            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
