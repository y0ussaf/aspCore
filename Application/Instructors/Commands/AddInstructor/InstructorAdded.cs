using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Instructors.Commands.AddInstructor
{
    class CourseAdded : INotification
    {
        public int InstructorId { get; set; }
        public class InstructorAddedHandler : INotificationHandler<CourseAdded>
        {
            public Task Handle(CourseAdded notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
