using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class UpdateEmploymentFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<UpdateEmploymentFeature> _logger;

		public UpdateEmploymentFeature(IDbContext db,
			ILogger<UpdateEmploymentFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Update an employment
		/// </summary>
		/// <param name="employment"></param>
		/// <returns></returns>
		public int Execute(EmploymentModel employment)
		{
			try
			{
				// check data
				if (employment.Id <= 0 ||
					!_db.Employments.Any(r => r.Id == employment.Id) ||
					!_db.Employees.Any(r => r.Id == employment.EmployeeId) ||
					string.IsNullOrWhiteSpace(employment.Company) ||
					string.IsNullOrWhiteSpace(employment.Position))
				{
					return 0;
				}

				// execute
				_db.Employments.First(r => r.Id == employment.Id).Company = employment.Company;
				_db.Employments.First(r => r.Id == employment.Id).Position = employment.Position;
				_db.SaveChanges();
				return employment.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while updating employment");
				return 0;
			}
		}
	}
}