using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMaster.Core.Entities
{
	public class Employment
	{
		[Key]
		public int Id { get; set; }

		public int EmployeeId { get; set; }

		[ForeignKey(nameof(EmployeeId))]
		public virtual Employee? Employee { get; set; }

		public string Company { get; set; } = string.Empty;

		public string Position { get; set;} = string.Empty;
	}
}
