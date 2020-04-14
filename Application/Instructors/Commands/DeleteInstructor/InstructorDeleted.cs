using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace Application.Instructors.Commands.DeleteInstructor
{
    class InstructorDeleted : INotification
    {
        public class InstructorAddedHandler : INotificationHandler<InstructorDeleted>
        {
            public Task Handle(InstructorDeleted notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
