using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
}
