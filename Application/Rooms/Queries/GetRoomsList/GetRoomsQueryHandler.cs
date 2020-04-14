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

namespace Application.Rooms.Queries.GetRoomsList
{
    class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery,RoomListVm>
    {
        public readonly IRepository _context;

        public GetRoomsQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<RoomListVm> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var count = await _context.Rooms.CountAsync();
            var result = _context.Rooms.Paginate(request.PageSize, request.Page).AsQueryable()
                                        .Select(r => new RoomDto()
                                        {
                                            Id = r.RoomId,
                                            Name = r.Name
                                        });
            var roomsDtos = await Task.FromResult(result.ToList());
            var roomsListVm = new RoomListVm(roomsDtos, count, request.Page, request.PageSize);
            return roomsListVm;
        }
    }
}
