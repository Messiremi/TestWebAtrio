using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class AddEmploymentFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<AddEmploymentFeature> _logger;

		public AddEmploymentFeature(IDbContext db,
			ILogger<AddEmploymentFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Add an employment
		/// </summary>
		/// <param name="employment"></param>
		/// <returns></returns>
		public int Execute(EmploymentModel	employment)
		{
			try
			{
				// check data
				if (!_db.Employees.Any(r=>r.Id == employment.EmployeeId) ||
					string.IsNullOrWhiteSpace(employment.Company) ||
					string.IsNullOrWhiteSpace(employment.Position))
				{
					return 0;
				}

				// execute
				Employment entity = new Employment() { EmployeeId = employment.EmployeeId, Company = employment.Company, Position = employment.Position };
				_db.Employments.Add(entity);
				_db.SaveChanges();
				return entity.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while adding new employment");
				return 0;
			}
		}
	}
}