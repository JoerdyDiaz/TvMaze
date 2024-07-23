using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace TvMazeApi.FilterAuthorization
{
    public class ApiKeyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string ApiKeyHeaderName;
        private readonly string _apiKey;

        public ApiKeyAuthorizationFilter(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("ApiKeyHeaderValue");
            ApiKeyHeaderName = configuration.GetValue<string>("ApiKeyHeaderName");
        }



        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!_apiKey.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
