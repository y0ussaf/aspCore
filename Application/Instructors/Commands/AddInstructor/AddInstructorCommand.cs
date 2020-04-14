using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Instructors.Commands.AddInstructor
{
    public class AddInstructorCommand : IRequest<int>
    { 
        public string Name { get; set; }

    }
}
