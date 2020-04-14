using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public int RoomId { get; set; }
    }
}
