using BookTouristRoutes.Api.Extensions;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.Api;

public class Startup
{
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

    services.RegisterAutoMapper();

    services.RegisterRepositories();
    services.RegisterCustomServices();

    services.ConfigureJwt(_configuration);

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

    services.AddAuthentication();
  }

  public void Configure(
    IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseCors("CorsPolicy");

    app.UseMiddleware<CustomExceptionHandlerMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseEndpoints(cfg =>
    {
      cfg.MapControllers();
    });

    InitializeDatabase(app);
  }

  private static void InitializeDatabase(IApplicationBuilder app)
  {
    using var scope = app.ApplicationServices
      .GetService<IServiceScopeFactory>()?
      .CreateScope();

    using var context = scope?.ServiceProvider
      .GetRequiredService<BookTouristRoutesContext>();

    context?.Database.Migrate();
  }
}
