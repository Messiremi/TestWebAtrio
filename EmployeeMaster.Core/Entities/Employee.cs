using System.ComponentModel.DataAnnotations;

namespace EmployeeMaster.Core.Entities
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		public string Firstname { get; set; } = string.Empty;

		public string Lastname { get; set; } = string.Empty;

		public DateTime Birthdate { get; set; }
	}
}