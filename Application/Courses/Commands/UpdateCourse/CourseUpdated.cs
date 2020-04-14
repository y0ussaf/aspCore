using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace Application.Courses.Commands.UpdateCourse
{
    class CourseUpdated : INotification
    {
        public class CourseUpdatedHandler : INotificationHandler<CourseUpdated>
        {
            public Task Handle(CourseUpdated notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
