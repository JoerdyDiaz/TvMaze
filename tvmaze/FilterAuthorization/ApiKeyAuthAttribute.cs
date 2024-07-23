using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

public class ApiKeyAuthAttribute : AuthorizationFilterAttribute
{
    private readonly string ApiKeyHeaderName = ConfigurationManager.AppSettings["ApiKeyHeaderName"];
    private readonly string ApiKeyValue = ConfigurationManager.AppSettings["ApiKeyHeaderValue"];

    public override void OnAuthorization(HttpActionContext actionContext)
    {
        if (!actionContext.Request.Headers.Contains(ApiKeyHeaderName))
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No autorizado");
            return;
        }

        var apiKey = actionContext.Request.Headers.GetValues(ApiKeyHeaderName).FirstOrDefault();
        if (apiKey != ApiKeyValue)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No autorizado");
            return;
        }

        base.OnAuthorization(actionContext);
    }
}
