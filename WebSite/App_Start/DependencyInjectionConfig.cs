using System.Web.Http;
using System.Web.Http.Dispatcher;
using AarhusDataAccessImpl;
using RequestHandlers;
using WebSite.Controllers;
using WebSite.Core;

namespace WebSite
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var typeInstanciator = new TypeInstanciator();
            typeInstanciator.AddCreator(() => new TraficController(new ResponseGenerator(), new TraficDataReader()));
            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), new PoorMansDI(typeInstanciator));
        }
    }
}