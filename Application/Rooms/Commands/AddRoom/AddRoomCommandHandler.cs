using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AddRoom
{
    class AddRoomCommandHandler : IRequestHandler<AddRoomCommand,int>
    {
        private readonly IRepository _context;

        public AddRoomCommandHandler(IRepository context)
        {
            _context = context;
        }
        public  async Task<int> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new Room
            {
                Name = request.Name
            };
            _context.Rooms.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.RoomId;
        }
    }
}
