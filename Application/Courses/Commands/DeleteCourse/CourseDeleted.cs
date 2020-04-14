using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace Application.Courses.Commands.DeleteCourse
{
    class CourseAdded : INotification
    {
        public class CourseAddedHandler : INotificationHandler<CourseAdded>
        {
            public Task Handle(CourseAdded notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
