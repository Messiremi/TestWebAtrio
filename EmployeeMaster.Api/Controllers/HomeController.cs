using EmployeeMaster.Application.Features;
using EmployeeMaster.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMaster.Api.Controllers
{
	/// <summary>
	/// Home page
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{
		private readonly ILogger<HomeController> _logger;
		private readonly GetEmployeesAndEmploymentsFeature _featureGetEmployeesAndEmployments;

		/// <summary>
		/// Home page
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="featureGetEmployeesAndEmployments"></param>
		public HomeController(ILogger<HomeController> logger,
			GetEmployeesAndEmploymentsFeature featureGetEmployeesAndEmployments)
		{
			_logger = logger;
			_featureGetEmployeesAndEmployments = featureGetEmployeesAndEmployments;
		}

		/// <summary>
		/// Get all employees and their employments
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("get")]
		public IEnumerable<EmployeeAndEmploymentsModel> GetEmployees()
		{
			return _featureGetEmployeesAndEmployments.Execute();
		}
	}
}