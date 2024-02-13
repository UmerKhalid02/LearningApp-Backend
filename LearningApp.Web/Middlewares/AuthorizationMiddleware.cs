using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.DataTransferObjects.Shared;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace LearningApp.Web.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var endPoint = context.GetEndpoint();

            if (endPoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
            {
                await _next(context);
                return;
            }

            string token = string.Empty;
            //token = context.Request.HttpContext.Request.Cookies[AuthCookiesValue.AuthKey];
            token = context.Request.HttpContext.Request.Headers["Authorization"];

            if (token == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new Response<dynamic>(false, "token is null"));
                return;
            }

            if (token == string.Empty)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new Response<dynamic>(false, "Unauthorized"));
                return;
            }

            /*var authToken = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtTokenRequestDTO>(token);
            if (authToken == null || authToken.JwtToken == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new Response<dynamic>(false, "Unauthorized"));
                return;
            }*/

            var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);

            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtConfig.ValidIssuer,
                    ValidAudience = JwtConfig.ValidAudience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);

                var claims = context.User.Identity as ClaimsIdentity;
                claims.AddClaims(principal.Claims);
                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new Response<dynamic>(false, "Unauthorized"));
                return;
            }
        }
    }
}
