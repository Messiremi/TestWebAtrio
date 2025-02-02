using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class UpdateEmployeeFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<UpdateEmployeeFeature> _logger;

		public UpdateEmployeeFeature(IDbContext db,
			ILogger<UpdateEmployeeFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Update an employee
		/// </summary>
		/// <param name="employee"></param>
		/// <returns></returns>
		public int Execute(EmployeeModel employee)
		{
			try
			{
				// check data
				if (employee.Id <= 0 || 
					!_db.Employees.Any(r=>r.Id == employee.Id) ||
					(DateTime.Today - employee.Birthdate).TotalDays / 365 >= 150 ||
					string.IsNullOrWhiteSpace(employee.Firstname) ||
					string.IsNullOrWhiteSpace(employee.Lastname))
				{
					return 0;
				}

				// execute
				_db.Employees.First(r => r.Id == employee.Id).Firstname = employee.Firstname;
				_db.Employees.First(r => r.Id == employee.Id).Lastname = employee.Lastname;
				_db.Employees.First(r => r.Id == employee.Id).Birthdate = employee.Birthdate;
				_db.SaveChanges();
				return employee.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while updating employee");
				return 0;
			}
		}
	}
}