using BookTouristRoutes.Api.Extensions;
using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.Api;

public class Startup // TODO connect angular
{// TODO connect JWT
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public void ConfigureServices(
    IServiceCollection services)
  {
    var migrationAssembly = typeof(BookTouristRoutesContext).Assembly.GetName().Name;
    services.AddDbContext<BookTouristRoutesContext>(options =>
      options.UseSqlServer(_configuration.GetConnectionString("DbConnection"),
        opt => opt.MigrationsAssembly(migrationAssembly))
        .EnableSensitiveDataLogging());

    services.RegisterCustomServices();
    services.RegisterRepositories();

    services.AddControllers();
    services.AddSwaggerGen();

    services.AddCors(options =>
    {
      options.AddPolicy("CorsPolicy",
        builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
    });

  }

  public void Configure(
    IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseCors("CorsPolicy");

    app.UseMiddleware<CustomExceptionHandlerMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseRouting();

    app.UseEndpoints(cfg =>
    {
      cfg.MapControllers();
    });
  }
}
