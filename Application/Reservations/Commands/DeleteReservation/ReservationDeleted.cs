using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.DeleteReservation
{
    class ReservationDeleted : INotification
    {
        public class ReservationDeletedHandler : INotificationHandler<ReservationDeleted>
        {
            public Task Handle(ReservationDeleted notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
