using EmployeeMaster.Application.Features;
using EmployeeMaster.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMaster.Api.Controllers
{
	/// <summary>
	/// Manage employees
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class EmployeesController : ControllerBase
	{
		private readonly ILogger<EmployeesController> _logger;
		private readonly GetEmployeesFeature _featureGetEmployees;

		/// <summary>
		/// Manage employees
		/// </summary>
		public EmployeesController(ILogger<EmployeesController> logger,
			GetEmployeesFeature featureGetEmployees)
		{
			_logger = logger;
			_featureGetEmployees = featureGetEmployees;
		}

		/// <summary>
		/// Get all employees
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("get")]
		public IEnumerable<EmployeeModel> GetEmployees()
		{
			return _featureGetEmployees.Execute();
		}
	}
}