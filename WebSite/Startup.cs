using System.Web.Http;
using Microsoft.Owin;
using Nancy.Owin;
using Owin;
using WebSite;

[assembly: OwinStartup(typeof(Startup))]
namespace WebSite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SetupApi(app);
            SetupWeb(app);
        }

        private static void SetupApi(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            DependencyInjectionConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }

        private static void SetupWeb(IAppBuilder app)
        {
            app.UseNancy(new NancyOptions());
        }
    }
}
