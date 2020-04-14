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
using Application.Courses.Queries.GetCourse;
using Domain.Entities;

namespace Application.Courses.Queries.GetCourse
{
     class GetReservationsQueryHandler : IRequestHandler<GetCourseQuery, CourseDto>
    {
        public readonly IRepository _context;
        public GetReservationsQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<CourseDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.CourseId);
            if (entity == null)
            {
                throw   new NotFoundException(nameof(Course),request.CourseId);
            }
            return new CourseDto()
            {
                Name = entity.Name,
                Id = entity.CourseId
            };
        }
    }
   
}
