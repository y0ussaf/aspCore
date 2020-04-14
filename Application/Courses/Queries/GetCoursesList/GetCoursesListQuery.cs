using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Courses.Queries.GetCoursesList
{
    public class GetCoursesListQuery : IRequest<CoursesListVm>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
