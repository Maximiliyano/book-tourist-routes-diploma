using System.Reflection;
using System.Text;
using BookTouristRoutes.BLL.Interfaces.JWT;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.JWT;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.BLL.Services;
using BookTouristRoutes.Common.MappingProfiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookTouristRoutes.Api.Extensions;

public static class ServiceExtension
{
  public static void RegisterCustomServices(this IServiceCollection service)
  {
    service.AddScoped<JwtIssuerOptions>();
    service.AddScoped<IJwtFactory, JwtFactory>();

    service.AddScoped<IImageService, ImageService>();
    service.AddScoped<IUserService, UserService>();
    service.AddScoped<IRouteService, RouteService>();
    service.AddScoped<IBookingService, BookingService>();
    service.AddScoped<IAuthService, AuthService>();
  }

  public static void RegisterRepositories(this IServiceCollection service)
  {
    service.AddScoped<IRouteRepository, RouteRepository>();
    service.AddScoped<IUserRepository, UserRepository>();
    service.AddScoped<IImageRepository, ImageRepository>();
    service.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    service.AddScoped<IBookingRepository, BookingRepository>();
  }

  public static void RegisterAutoMapper(this IServiceCollection services)
  {
    services.AddAutoMapper(cfg =>
    {
      cfg.AddProfile<UserProfile>();
    },
    Assembly.GetExecutingAssembly());
  }

  public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
  {
      var secretKey = configuration["Jwt:SecretKey"];

      if (secretKey == null) return;

      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

      var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
      });

      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

        ValidateAudience = true,
        ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        RequireExpirationTime = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
      };

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

      }).AddJwtBearer(configureOptions =>
      {
        configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        configureOptions.TokenValidationParameters = tokenValidationParameters;
        configureOptions.SaveToken = true;

        configureOptions.Events = new JwtBearerEvents
        {
          OnAuthenticationFailed = context =>
          {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
              context.Response.Headers.Add("Token-Expired", "true");
            }

            return Task.CompletedTask;
          }
        };
      });
  }
}
