using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using API.Controllers;

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

    public class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        private readonly ICollection<Assembly> _assemblies;

        public CustomAssembliesResolver()
        {
            _assemblies = base.GetAssemblies();
        }


        public ICollection<Assembly> GetAssemblies()
        {
            return _assemblies;
        }

        public void AddAssemblyFromType(Type type)
        {
            _assemblies.Add(type.Assembly);
        }
    }
}