using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class AddEmployeeFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<AddEmployeeFeature> _logger;

		public AddEmployeeFeature(IDbContext db,
			ILogger<AddEmployeeFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Add an employee
		/// </summary>
		/// <param name="employee"></param>
		/// <returns></returns>
		public int Execute(EmployeeModel employee)
		{
			try
			{
				// check data
				if((DateTime.Today - employee.Birthdate).TotalDays / 365 >= 150 ||
					string.IsNullOrWhiteSpace(employee.Firstname) ||
					string.IsNullOrWhiteSpace(employee.Lastname))
				{
					return 0;
				}

				// execute
				Employee entity = new Employee() { Firstname = employee.Firstname, Lastname = employee.Lastname, Birthdate = employee.Birthdate };
				_db.Employees.Add(entity);
				_db.SaveChanges();
				return entity.Id;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error while adding new employee");
				return 0;
			}
		}
	}
}