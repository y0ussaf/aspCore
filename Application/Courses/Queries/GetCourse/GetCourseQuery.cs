using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Courses.Queries.GetCourse
{
    public class GetCourseQuery : IRequest<CourseDto>
    {
        public int CourseId { get; set; }
    }
}
