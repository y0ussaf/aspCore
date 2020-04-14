using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Instructors.Commands.DeleteInstructor
{
    class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand>
    {
        private readonly IRepository _context;

        public DeleteInstructorCommandHandler(IRepository context, IMediator mediator)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Instructors
                .FindAsync(request.InstructorId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Instructor), request.InstructorId);
            }       
            _context.Instructors.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
