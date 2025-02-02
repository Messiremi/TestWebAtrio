using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaster.Application.Features
{
	public class GetEmployeesAndEmploymentsFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<GetEmployeesAndEmploymentsFeature> _logger;

		public GetEmployeesAndEmploymentsFeature(IDbContext db,
			ILogger<GetEmployeesAndEmploymentsFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Get all the employees and their employments
		/// </summary>
		/// <returns></returns>
		public List<EmployeeAndEmploymentsModel> Execute()
		{
			List<EmployeeAndEmploymentsModel> employeesAndEmployments = new();

			try
			{
				// employees first
				_db.Employees.ToList().ForEach(r =>
				{
					employeesAndEmployments.Add(new EmployeeAndEmploymentsModel()
					{
						Firstname = r.Firstname,
						Lastname = r.Lastname,
						Birthdate = r.Birthdate,
						Id = r.Id
					});
				});
				// then all employments and map them to employees
				_db.Employments.ToList().ForEach(r =>
				{
					if (employeesAndEmployments.Any(s => s.Id == r.EmployeeId))
					{
						employeesAndEmployments.First(s => s.Id == r.EmployeeId).Employments.Add(new EmploymentModel()
						{
							EmployeeId = r.EmployeeId,
							Company = r.Company,
							Id = r.Id,
							Position = r.Position
						});
					}
				});
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error while loading employees and employments");
			}

			return employeesAndEmployments;
		}
	}
}
