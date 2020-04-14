using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Courses.Commands.AddCourse
{
    public class AddCourseCommand : IRequest<int>
    { 
        public string Name { get; set; }
    }
}
