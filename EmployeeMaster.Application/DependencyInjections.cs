using EmployeeMaster.Application.Features;
using EmployeeMaster.Application.Helpers;
using EmployeeMaster.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMaster.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			// fake data
			var serviceProvider = services.BuildServiceProvider();
			serviceProvider.GetRequiredService<IDbContext>().AddFakeData();

			// features
			services.AddTransient<AddEmployeeFeature>();
			services.AddTransient<AddEmploymentFeature>();
			services.AddTransient<DeleteEmployeeFeature>();
			services.AddTransient<DeleteEmploymentFeature>();
			services.AddTransient<GetEmployeesAndEmploymentsFeature>();
			services.AddTransient<GetEmployeeFeature>();
			services.AddTransient<GetEmployeesFeature>();
			services.AddTransient<GetEmploymentFeature>();
			services.AddTransient<GetEmploymentsFeature>();
			services.AddTransient<UpdateEmployeeFeature>();
			services.AddTransient<UpdateEmploymentFeature>();
			return services;
		}
	}
}