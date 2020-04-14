using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Application.Instructors.Commands.UpdateInstructor
{
    public class UpdateInstructorCommand : IRequest
    {
        public int InstructorId { get; set; }
        public String Name { get; set; }
    }
}
