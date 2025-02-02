using EmployeeMaster.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeMaster.Application.Features
{
	public class DeleteEmployeeFeature
	{
		private readonly IDbContext _db;
		private readonly ILogger<DeleteEmployeeFeature> _logger;

		public DeleteEmployeeFeature(IDbContext db,
			ILogger<DeleteEmployeeFeature> logger)
		{
			_db = db;
			_logger = logger;
		}

		/// <summary>
		/// Delete an employee
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Execute(int id)
		{
			try
			{
				// check data
				if (!_db.Employees.Any(r => r.Id == id) ||
					_db.Employments.Any(r=>r.EmployeeId == id))
				{
					return false;
				}

				// execute
				_db.Employees.Remove(_db.Employees.Where(r => r.Id == id).First());
				_db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while deleting employee");
				return false;
			}
		}
	}
}