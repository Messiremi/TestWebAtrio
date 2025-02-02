using EmployeeMaster.Application;
using EmployeeMaster.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{

	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Host.UseSerilog((context, configuration) =>
 {
	 var config = context.Configuration;
	 configuration.ReadFrom.Configuration(config);
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
