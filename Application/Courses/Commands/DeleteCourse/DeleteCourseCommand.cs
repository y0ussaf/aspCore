using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public int CourseId { get; set; }
    }
}
