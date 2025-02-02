using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class GetEmploymentsFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<GetEmploymentsFeature> _logger;

		public GetEmploymentsFeature(IDbContext db,
			ILogger<GetEmploymentsFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Get all the employments
		/// </summary>
		/// <returns></returns>
		public List<EmploymentModel> Execute()
		{
			List<EmploymentModel> employments = new();

			try
			{
				_db.Employments.ToList().ForEach(r =>
				{
					employments.Add(new EmploymentModel()
					{
						Company = r.Company,
						Position = r.Position,
						EmployeeId = r.EmployeeId,
						Id = r.Id
					});
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while loading employments");
			}

			return employments;
		}
	}
}