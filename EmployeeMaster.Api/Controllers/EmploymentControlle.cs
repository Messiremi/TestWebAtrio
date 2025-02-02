using EmployeeMaster.Application.Features;
using EmployeeMaster.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentMaster.Api.Controllers
{
	/// <summary>
	/// Manage an employment
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class EmploymentController : ControllerBase
	{
		private readonly ILogger<EmploymentController> _logger;
		private readonly GetEmploymentFeature _featureGetEmployment;
		private readonly AddEmploymentFeature _featureAddEmployment;
		private readonly UpdateEmploymentFeature _featureUpdateEmployment;
		private readonly DeleteEmploymentFeature _featureDeleteEmployment;

		/// <summary>
		/// Manage an employment
		/// </summary>
		public EmploymentController(ILogger<EmploymentController> logger,
			GetEmploymentFeature featureGetEmployment,
			AddEmploymentFeature featureAddEmployment,
			UpdateEmploymentFeature featureUpdateEmployment,
			DeleteEmploymentFeature featureDeleteEmployment)
		{
			_logger = logger;
			_featureGetEmployment = featureGetEmployment;
			_featureAddEmployment = featureAddEmployment;
			_featureUpdateEmployment = featureUpdateEmployment;
			_featureDeleteEmployment = featureDeleteEmployment;
		}

		/// <summary>
		/// Get an employment
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("get")]
		public EmploymentModel? GetEmployment([FromBody] int id)
		{
			return _featureGetEmployment.Execute(id);
		}

		/// <summary>
		/// Create new employment and get created employment model with it
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("create")]
		public EmploymentModel? CreateEmployment([FromBody] EmploymentModel employment)
		{
			int result = _featureAddEmployment.Execute(employment);
			if (result > 0)
			{
				return _featureGetEmployment.Execute(result);
			}
			return null;
		}

		/// <summary>
		/// Update an existing employment and get updated employment model with it
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("update")]
		public EmploymentModel? UpdateEmployment([FromBody] EmploymentModel employment)
		{
			int result = _featureUpdateEmployment.Execute(employment);
			if (result > 0)
			{
				return _featureGetEmployment.Execute(result);
			}
			return null;
		}

		/// <summary>
		/// Delete an employment
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("delete")]
		public bool DeleteEmployment([FromBody] EmploymentModel employment)
		{
			return _featureDeleteEmployment.Execute(employment.Id);
		}
	}
}