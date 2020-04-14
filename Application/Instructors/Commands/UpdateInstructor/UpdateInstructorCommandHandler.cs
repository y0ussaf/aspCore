using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Instructors.Commands.UpdateInstructor
{
     class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand>
    {
      
            private readonly IRepository _context;

            public UpdateInstructorCommandHandler(IRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Instructors.FindAsync(request.InstructorId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Instructor), request.InstructorId);
                }
            entity.Name = request.Name;

            _context.Instructors.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
    }
    
}
