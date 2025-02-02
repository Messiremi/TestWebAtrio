using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMaster.Infrastructure
{
	public class EmployeeMasterContext : DbContext, IDbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Employment> Employments { get; set; }

		public EmployeeMasterContext()
		{

		}

		public EmployeeMasterContext(DbContextOptions options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("EmployeeMaster");
		}
	}
}