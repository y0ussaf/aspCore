using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.UpdateReservation
{
    class ReservationUpdated : INotification
    {
        public int RoomId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public class ReservationUpdatedHandler : INotificationHandler<ReservationUpdated>
        {

            public Task Handle(ReservationUpdated notification, CancellationToken cancellationToken)
            {
                Console.WriteLine("rooom added ");
                return Task.CompletedTask;
            }
        }
    }
}
