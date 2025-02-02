namespace EmployeeMaster.Core.Models
{
	public class EmploymentModel
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public string Company { get; set; } = string.Empty;
		public string Position { get; set; } = string.Empty;
	}
}