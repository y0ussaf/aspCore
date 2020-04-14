using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Courses.Commands.AddCourse
{
    class AddCourseCommandHandler : IRequestHandler<AddCourseCommand,int>
    {
        public readonly IRepository _context;

        public AddCourseCommandHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Course()
            {
                Name = request.Name
            };
            _context.Courses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.CourseId;
        }
    }
}
