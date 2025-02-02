namespace EmployeeMaster.Core.Models
{
	public class EmployeeAndEmploymentsModel
	{
		public int Id { get; set; }
		public string Firstname { get; set; } = string.Empty;
		public string Lastname { get; set; } = string.Empty;
		public DateTime Birthdate { get; set; }
		public List<EmploymentModel> Employments { get; set; } = new List<EmploymentModel>();
	}
}