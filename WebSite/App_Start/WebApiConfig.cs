using System.Web.Http;
using System.Web.Http.Dispatcher;
using API.Controllers;
using API.Core;

namespace WebSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var assembliesResolver = new CustomAssembliesResolver();
            assembliesResolver.AddAssemblyFromType(typeof (HomeController));
            config.Services.Replace(typeof (IAssembliesResolver), assembliesResolver);
            config.MapHttpAttributeRoutes();
        }
    }
}