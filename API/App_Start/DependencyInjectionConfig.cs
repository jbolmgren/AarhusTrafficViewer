using System.Web.Http;
using System.Web.Http.Dispatcher;
using AarhusDataAccessImpl;
using API.Controllers;
using API.Core;
using RequestHandlers;

namespace API
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