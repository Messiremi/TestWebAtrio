using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class GetEmploymentFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<GetEmploymentFeature> _logger;

		public GetEmploymentFeature(IDbContext db,
			ILogger<GetEmploymentFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Get an employment
		/// </summary>
		/// <returns></returns>
		public EmploymentModel? Execute(int id)
		{
			try
			{
				Employment? employment = _db.Employments.FirstOrDefault(r => r.Id == id);
				if (employment != null)
				{
					return new EmploymentModel()
					{
						Company = employment.Company,
						Position = employment.Position,
						Id = employment.Id,
						EmployeeId = employment.EmployeeId
					};
				}
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while loading employment");
				return null;
			}
		}
	}
}