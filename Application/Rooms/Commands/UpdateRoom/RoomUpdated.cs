using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace Application.Rooms.Commands.UpdateRoom
{
    class RoomUpdated  : INotification
    {
        public class RoomUpdatedHandler : INotificationHandler<RoomUpdated>
        {
            public async Task Handle(RoomUpdated notification, CancellationToken cancellationToken)
            {
                 
            }
        }
    }
}
