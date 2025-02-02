using EmployeeMaster.Application.Features;
using EmployeeMaster.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMaster.Api.Controllers
{
	/// <summary>
	/// Manage an employee
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly ILogger<EmployeeController> _logger;
		private readonly GetEmployeeFeature _featureGetEmployee;
		private readonly AddEmployeeFeature _featureAddEmployee;
		private readonly UpdateEmployeeFeature _featureUpdateEmployee;
		private readonly DeleteEmployeeFeature _featureDeleteEmployee;

		/// <summary>
		/// Manage an employee
		/// </summary>
		public EmployeeController(ILogger<EmployeeController> logger,
			GetEmployeeFeature featureGetEmployee,
			AddEmployeeFeature featureAddEmployee,
			UpdateEmployeeFeature featureUpdateEmployee,
			DeleteEmployeeFeature featureDeleteEmployee)
		{
			_logger = logger;
			_featureGetEmployee = featureGetEmployee;
			_featureAddEmployee = featureAddEmployee;
			_featureUpdateEmployee	= featureUpdateEmployee;
			_featureDeleteEmployee = featureDeleteEmployee;
		}

		/// <summary>
		/// Get an employee
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("get")]
		public EmployeeModel? GetEmployee([FromBody] int id)
		{
			return _featureGetEmployee.Execute(id);
		}

		/// <summary>
		/// Create new employee and get created employee model with it
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("create")]
		public EmployeeModel? CreateEmployee([FromBody] EmployeeModel employee)
		{
			int result = _featureAddEmployee.Execute(employee);
			if (result > 0)
			{
				return _featureGetEmployee.Execute(result);
			}
			return null;
		}

		/// <summary>
		/// Update an existing employee and get updated employee model with it
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("update")]
		public EmployeeModel? UpdateEmployee([FromBody] EmployeeModel employee)
		{
			int result = _featureUpdateEmployee.Execute(employee);
			if (result > 0)
			{
				return _featureGetEmployee.Execute(result);
			}
			return null;
		}

		/// <summary>
		/// Delete an employee
		/// </summary>
		/// <returns></returns>
		[HttpPost, Route("delete")]
		public bool DeleteEmployee([FromBody] EmployeeModel employee)
		{
			return _featureDeleteEmployee.Execute(employee.Id);
		}
	}
}