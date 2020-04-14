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

namespace Application.Instructors.Queries.GetInstructorsList
{
     class GetReservationsQueryHandler : IRequestHandler<GetInstructorsListQuery, InstructorListVm>
    {
        private readonly IRepository _context;

        public GetReservationsQueryHandler(IRepository context)
        {
            _context = context;
        }

        public async Task<InstructorListVm> Handle(GetInstructorsListQuery request, CancellationToken cancellationToken)
        {
            var count = await _context.Instructors.CountAsync();
            var result = _context.Instructors.Paginate(request.PageSize, request.Page).AsQueryable()
                                        .Select(c => new InstructorDto()
                                        {
                                            Id = c.InstructorId,
                                            Name = c.Name
                                        });
            var instructorsDtos = await Task.FromResult(result.ToList());
            var InstructorsListVm = new InstructorListVm(instructorsDtos, count, request.Page, request.PageSize);
            return InstructorsListVm;
         }
    }
   
}
