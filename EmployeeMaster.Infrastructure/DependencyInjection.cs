using EmployeeMaster.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMaster.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<IDbContext, EmployeeMasterContext>(options => options.UseInMemoryDatabase("EmployeeMaster"));
			services.AddTransient<IDbContext, EmployeeMasterContext>();
			return services;
		}
	}
}