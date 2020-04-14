using Application.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Instructors.Queries.GetInstructorsList
{
	public class InstructorListVm : Paged
	{
		public InstructorListVm()
		{
		}

		public List<InstructorDto> Instructors { get; set; }
	
		public InstructorListVm(List<InstructorDto> items, int count, int pageNumber, int pageSize) 
			: base(count,pageNumber,pageSize)
		{
			Instructors = items;
		
 		}

	}
}
