using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Auth.Authentication
{
    public class ApiKeyMiddleware 
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;
        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _configuration = config;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var providedKey= context.Request.Headers[AuthConfig.ApiKeyHeader].FirstOrDefault();
      
            if (! IsValidApiKey(providedKey) )
            {
                await GenerateResponse(context, 401, "Invalid Authentication");
                return;


            }

            await _next(context);
        
        }

        private async Task GenerateResponse(HttpContext context, int httpStatusCode, string message)
        {
           context.Response.StatusCode = httpStatusCode;
            await context.Response.WriteAsync(message);
        }

        private bool IsValidApiKey(string? apiKey)
        {

            var validApiKey = _configuration.GetValue<string>(AuthConfig.AuthSection);

            return string.Equals(validApiKey, apiKey);
        }
    }
}
