using Application.Common.Extensions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Instructors.Queries.GetInstructor;
using Domain.Entities;

namespace Application.Courses.Queries.GetInstructor
{
     class GetInstructorQueryHandler : IRequestHandler<GetInstructorQuery, InstructorDto>
    {
        public readonly IRepository _context;
        public GetInstructorQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<InstructorDto> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Instructors.FindAsync(request.InstructorId);
            if (entity == null)
            {
                throw   new NotFoundException(nameof(Instructor),request.InstructorId);
            }
            return new InstructorDto()
            {
                Name = entity.Name,
                Id = entity.InstructorId
            };
        }
    }
   
}
