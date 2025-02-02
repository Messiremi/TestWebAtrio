using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class GetEmployeeFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<GetEmployeeFeature> _logger;

		public GetEmployeeFeature(IDbContext db,
			ILogger<GetEmployeeFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Get an employee
		/// </summary>
		/// <returns></returns>
		public EmployeeModel? Execute(int id)
		{
			try
			{
				Employee? employee = _db.Employees.FirstOrDefault(r => r.Id == id);
				if(employee != null)
				{
					return new EmployeeModel()
					{
						Birthdate = employee.Birthdate,
						Firstname = employee.Firstname,
						Id = employee.Id,
						Lastname = employee.Lastname,
						IsEmployed = _db.Employments.Any(r => r.EmployeeId == employee.Id),
					};
				}
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while loading employee");
				return null;
			}
		}
	}
}