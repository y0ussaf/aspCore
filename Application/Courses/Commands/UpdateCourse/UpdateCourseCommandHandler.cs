using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Courses.Commands.UpdateCourse
{
    class AddInstructorCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IRepository _context;

        public AddInstructorCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.CourseId);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Course), request.CourseId);
            }
            entity.Name = request.Name;
            _context.Courses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
