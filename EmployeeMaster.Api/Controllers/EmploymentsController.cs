using EmployeeMaster.Application.Features;
using EmployeeMaster.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentMaster.Api.Controllers
{
	/// <summary>
	/// Manage employments
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class EmploymentsController : ControllerBase
	{
		private readonly ILogger<EmploymentsController> _logger;
		private readonly GetEmploymentsFeature _featureGetEmployments;

		/// <summary>
		/// Manage employments
		/// </summary>
		public EmploymentsController(ILogger<EmploymentsController> logger,
			GetEmploymentsFeature featureGetEmployments)
		{
			_logger = logger;
			_featureGetEmployments = featureGetEmployments;
		}

		/// <summary>
		/// Get all employments
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("get")]
		public IEnumerable<EmploymentModel> GetEmployments()
		{
			return _featureGetEmployments.Execute();
		}
	}
}