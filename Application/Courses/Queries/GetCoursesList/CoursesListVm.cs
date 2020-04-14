using Application.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Courses.Queries.GetCoursesList
{
	public class CoursesListVm : Paged
	{
	
		public List<CourseDto> Courses { get; set; }
	
		public CoursesListVm(List<CourseDto> items, int count, int pageNumber, int pageSize) 
			: base(count,pageNumber,pageSize)
		{
			Courses = items;
		
 		}

		public CoursesListVm()
		{
			Courses = new List<CourseDto>();
		}
	}
}
