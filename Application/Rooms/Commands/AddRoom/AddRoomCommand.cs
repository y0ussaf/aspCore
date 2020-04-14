using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Rooms.Commands.AddRoom
{
   public class AddRoomCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
