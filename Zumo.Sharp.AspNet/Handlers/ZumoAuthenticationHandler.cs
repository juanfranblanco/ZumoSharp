using System.Net.Http;
using System.Security.Principal;
using System.Threading;

namespace Zumo.Sharp.AspNet.Handlers
{
    //example from https://github.com/mirajavora/WebAPISample/blob/master/WebApiBlog/Core/Handlers/AuthenticationHandler.cs
    public class ZumoAuthenticationHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var zumoAuthenticationTokenValidator = new ZumoAuthenticationTokenRequestInspector();

            var identity = zumoAuthenticationTokenValidator.ExtractIdentity(request);
            if (identity != null)
            {
                //TODO: Get roles... inject user repository
                var principal = new GenericPrincipal(identity, new[] {"User"});
                Thread.CurrentPrincipal = principal;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }

}


