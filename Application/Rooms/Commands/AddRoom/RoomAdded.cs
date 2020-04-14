using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.AddRoom
{
    class RoomUpdated : INotification
    {
        public int RoomId { get; set; }

        public class RoomAddedHandler : INotificationHandler<RoomUpdated>
        {
           
            public Task Handle(RoomUpdated notification, CancellationToken cancellationToken)
            {
                Console.WriteLine("rooom added ");
                return Task.CompletedTask;
            }
        }
    }
}
