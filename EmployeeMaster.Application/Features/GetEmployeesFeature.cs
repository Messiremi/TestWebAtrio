using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class GetEmployeesFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<GetEmployeesFeature> _logger;

		public GetEmployeesFeature(IDbContext db,
			ILogger<GetEmployeesFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Get all the employees
		/// </summary>
		/// <returns></returns>
		public List<EmployeeModel> Execute()
		{
			List<EmployeeModel> employees = new();

			try
			{
				List<int> employed = _db.Employments.Select(r => r.EmployeeId).Distinct().ToList();
				_db.Employees.ToList().ForEach(r =>
				{
					employees.Add(new EmployeeModel()
					{
						Firstname = r.Firstname,
						Lastname = r.Lastname,
						Birthdate = r.Birthdate,
						Id = r.Id,
						IsEmployed = employed.Contains(r.Id)
					});
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while loading employees");
			}

			return employees;
		}
	}
}