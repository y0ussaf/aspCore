using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Instructors.Queries.GetInstructorsList
{
   public class GetInstructorsListQuery : IRequest<InstructorListVm>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
