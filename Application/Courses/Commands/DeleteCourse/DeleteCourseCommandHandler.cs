using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Courses.Commands.DeleteCourse
{
    class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IRepository _context;

        public DeleteCourseCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses
                 .FindAsync(request.CourseId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Course), request.CourseId);
            }
            _context.Courses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
