using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Instructors.Commands.DeleteInstructor
{
    public class DeleteInstructorCommand : IRequest
    {
        public int InstructorId { get; set; }
    }
}
