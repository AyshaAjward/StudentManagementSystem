using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationSystem
{
	public class Student
	{
		[Key]
		public string RegNo { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Age { get; set; } = string.Empty;
		public string Department { get; set; } = string.Empty;
		public string YearOfStudy { get; set; } = string.Empty;

		public string Courses { get; set; } = string.Empty;


	}
}
