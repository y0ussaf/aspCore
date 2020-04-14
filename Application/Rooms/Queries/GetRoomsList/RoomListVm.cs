using Application.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Rooms.Queries.GetRoomsList
{
   public class RoomListVm : Paged
    {
        public RoomListVm()
        {
        }

        public List<RoomDto> Rooms { get; set; }
        public RoomListVm(List<RoomDto> rooms,int count, int pageNumber, int pageSize) : base(count, pageNumber, pageSize)
        {
            Rooms = rooms;
        }
    }
}
