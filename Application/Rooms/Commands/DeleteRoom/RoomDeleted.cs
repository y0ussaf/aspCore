using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.DeleteRoom
{
    class RoomDeleted : INotification
    {
        public class RoomDeletedHandler : INotificationHandler<RoomDeleted>
        {
            public Task Handle(RoomDeleted notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
