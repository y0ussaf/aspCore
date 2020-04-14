using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Instructors.Queries.GetInstructor;

namespace Application.Instructors.Queries.GetInstructor
{
    public class GetInstructorQuery : IRequest<InstructorDto>
    {
        public int InstructorId { get; set; }
    }
}
