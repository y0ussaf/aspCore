using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Instructors.Commands.AddInstructor
{
    class AddInstructorCommandHandler : IRequestHandler<AddInstructorCommand,int>
    {
        public readonly IRepository _context;

        public AddInstructorCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Instructor()
            {
                Name = request.Name
            };
            _context.Instructors.Add(entity);
           await _context.SaveChangesAsync(cancellationToken);
           return entity.InstructorId;
        }
    }
}
