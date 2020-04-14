using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Rooms.Commands.UpdateRoom
{
   public class UpdateRoomCommand : IRequest
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
    }
}
