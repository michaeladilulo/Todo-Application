using System;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Serialization;
using TodoApplication.Controllers;
using TodoApplication.Repositories;

namespace TodoApplication
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddCors(cors =>
			{
				cors.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			services.AddControllersWithViews().AddNewtonsoftJson(options =>
			options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
				.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

			services.AddControllers();
			services.AddScoped<IDbConnection>(x => CreateDbConnection());
			services.AddTransient<TodosService>();
			services.AddTransient<TodosRepository>();

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}

		private IDbConnection CreateDbConnection()
		{
			string connectionString = Configuration["db:gearhost"];
			return new MySqlConnection(connectionString);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}












/*
 var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
*/