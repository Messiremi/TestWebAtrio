namespace EmployeeMaster.Core.Models
{
	public class EmployeeModel
	{
		public int Id { get; set; }
		public string Firstname { get; set; } = string.Empty;
		public string Lastname { get; set; } = string.Empty;
		public DateTime Birthdate { get; set; }
		public bool IsEmployed { get; set; }
	}
}