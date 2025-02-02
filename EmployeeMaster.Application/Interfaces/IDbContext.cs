using EmployeeMaster.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace EmployeeMaster.Application.Interfaces
{
	public interface IDbContext
	{
		DbSet<Employee> Employees { get; }
		DbSet<Employment> Employments { get; }
		int SaveChanges();
	}
}