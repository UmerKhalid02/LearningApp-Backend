using LearningApp.Application.DataTransferObjects.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace LearningApp.Web.Extensions
{
    public static class JwtTokenConfig
    {
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration, byte[] key)
        {
            var jwtSection = configuration.GetSection("JWT");
            services.Configure<JwtConfig>(jwtSection);

            JwtConfig.Secret = jwtSection.GetSection("Secret").Value;
            JwtConfig.ValidIssuer = jwtSection.GetSection("ValidIssuer").Value;
            JwtConfig.ValidAudience = jwtSection.GetSection("ValidAudience").Value;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer("Fit", x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters()
                 {
                     RequireExpirationTime = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = JwtConfig.ValidIssuer,
                     ValidAudience = JwtConfig.ValidAudience,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("Fit")
                    .Build();

                options.AddPolicy("FitPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Fit");
                    policy.RequireClaim("project_scope", "Fit");
                });
            });
            return services;
        }
    }
}
