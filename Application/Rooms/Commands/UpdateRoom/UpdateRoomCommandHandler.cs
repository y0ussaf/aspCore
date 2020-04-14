using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Rooms.Commands.UpdateRoom
{
    class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IRepository _context;

        public UpdateRoomCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.RoomId);
            if(entity == null)
            {
                throw new  NotFoundException(nameof(Room),request.RoomId);
            }
             entity.Name = request.Name;

            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
