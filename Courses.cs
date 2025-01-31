using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem
{
    public class Courses
    {
		[Key]
		public string CourseID { get; set; } = string.Empty;
		public string CourseName { get; set; } = string.Empty;
		public string Credits { get; set; } = string.Empty;

	}
}
