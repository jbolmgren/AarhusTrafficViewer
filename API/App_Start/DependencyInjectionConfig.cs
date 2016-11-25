using System.Web.Http;
using System.Web.Http.Dispatcher;
using API.Core;

namespace API
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var typeInstanciator = new TypeInstanciator();

            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), new PoorMansDI(typeInstanciator));
        }
    }
}