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

namespace Application.Courses.Queries.GetCoursesList
{
     class GetReservationsQueryHandler : IRequestHandler<GetCoursesListQuery, CoursesListVm>
    {
        public readonly IRepository _context;
        public GetReservationsQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<CoursesListVm> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {
            var count = await _context.Courses.CountAsync();
            var result =  _context.Courses.Paginate(request.PageSize, request.Page)
                                        .Select(c => new CourseDto()
                                        {
                                            Id = c.CourseId,
                                            Name = c.Name
                                        });
            var coursesDtos = await Task.FromResult(result.ToList());
            var coursesListVm = new CoursesListVm(coursesDtos, count, request.Page, request.PageSize);
            return coursesListVm;
        }
    }
   
}
