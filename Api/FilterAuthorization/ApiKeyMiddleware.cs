using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace Api.FilterAuthorization
{
    public class ApiKeyMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly string API_KEY_HEADER_NAME ;
        private readonly string API_KEY_HEADER_value;
        private readonly string[] _excludedRoutes ;


        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _excludedRoutes = configuration.GetSection("ExcludedRoutes").Get<string[]>();
            API_KEY_HEADER_NAME = configuration.GetSection("ApiKeyHeaderName").Value;
            API_KEY_HEADER_value = configuration.GetSection("ApiKeyHeaderValue").Value;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            var path = context.Request.Path.Value;

            // Check if the current request path is in the excluded routes
            if (_excludedRoutes.Any(route => path.StartsWith(route)))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; 
                await context.Response.WriteAsync("API Key was not provided.");
                return;
            }

          
            var apiKey = API_KEY_HEADER_value;

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            await _next(context);
        }
    }
}
