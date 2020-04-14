using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.ReserveRoom
{
    class RoomReserved : INotification
    {
        public int RoomId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public class RoomReservedHandler : INotificationHandler<RoomReserved>
        {

            public Task Handle(RoomReserved notification, CancellationToken cancellationToken)
            {
                Console.WriteLine("rooom reserved ");
                return Task.CompletedTask;
            }
        }
    }
}
