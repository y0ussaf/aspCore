﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Application.Rooms.Queries.GetRoomsList
{
    public class GetRoomsQuery : IRequest<RoomListVm>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
