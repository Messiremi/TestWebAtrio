using EmployeeMaster.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class DeleteEmploymentFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<DeleteEmploymentFeature> _logger;

		public DeleteEmploymentFeature(IDbContext db,
			ILogger<DeleteEmploymentFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Delete an employment
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Execute(int id)
		{
			try
			{
				// check data
				if (!_db.Employments.Any(r => r.EmployeeId == id))
				{
					return false;
				}

				// execute
				_db.Employments.Remove(_db.Employments.Where(r => r.Id == id).First());
				_db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while deleting employment");
				return false;
			}
		}
	}
}