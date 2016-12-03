using System.Web.Http;
using System.Web.Http.Dispatcher;
using AarhusDataAccessImpl;
using API.Controllers;
using API.Core;

namespace WebSite
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var typeInstanciator = new TypeInstanciator();
            typeInstanciator.AddCreator(CreateInstances);
            httpConfiguration.Services.Replace(typeof (IHttpControllerActivator), new PoorMansDI(typeInstanciator));
        }

        private static TraficController CreateInstances()
        {
            return new TraficController(
                new ResponseGenerator(),
                new TraficDataReaderImpl(
                    new HttpJsonClientImpl(
                        new JsonConverterImpl()
                        )
                    ),
                new AutoMapperImpl.AutoMapperImpl()
                );
        }
    }
}