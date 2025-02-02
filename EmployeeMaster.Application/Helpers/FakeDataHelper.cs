using EmployeeMaster.Application.Interfaces;
using EmployeeMaster.Core.Entities;

namespace EmployeeMaster.Application.Helpers
{
	internal static class FakeDataHelper
	{
		internal static void AddFakeData(this IDbContext db)
		{
			try
			{
				Employee employee1 = new Core.Entities.Employee() { Firstname = "Jean", Lastname = "Martin", Birthdate = new DateTime(1980, 12, 24) };
				Employee employee2 = new Core.Entities.Employee() { Firstname = "Paul", Lastname = "Martin", Birthdate = new DateTime(1983, 10, 01) };
				Employee employee3 = new Core.Entities.Employee() { Firstname = "Louis", Lastname = "Bernard", Birthdate = new DateTime(1992, 02, 11) };
				Employee employee4 = new Core.Entities.Employee() { Firstname = "Jacques", Lastname = "Blanc", Birthdate = new DateTime(1999, 05, 19) };

				db.Employees.Add(employee1);
				db.Employees.Add(employee2);
				db.Employees.Add(employee3);
				db.Employees.Add(employee4);
				db.SaveChanges();

				Employment employment1 = new Core.Entities.Employment() { EmployeeId = employee1.Id, Company = "Super Software Company", Position = "Developer" };
				Employment employment2 = new Core.Entities.Employment() { EmployeeId = employee2.Id, Company = "Best City Restaurant", Position = "Polyvalent employee" };
				Employment employment3 = new Core.Entities.Employment() { EmployeeId = employee3.Id, Company = "Super Backery", Position = "Part time cook" };
				Employment employment4 = new Core.Entities.Employment() { EmployeeId = employee3.Id, Company = "City Post Office", Position = "Postman" };
				db.SaveChanges();
			}
			catch (Exception)
			{
			}
		}
	}
}
