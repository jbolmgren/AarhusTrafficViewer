using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebSite.Core
{
    public class PoorMansDI : IHttpControllerActivator
    {
        private readonly IHttpControllerActivator _defaultResolver = new DefaultHttpControllerActivator();
        private readonly TypeInstanciator _typeInstanciator;

        public PoorMansDI(TypeInstanciator typeInstanciator)
        {
            _typeInstanciator = typeInstanciator;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (_typeInstanciator.Contains(controllerType))
                return _typeInstanciator.Create(controllerType);

            return _defaultResolver.Create(request, controllerDescriptor, controllerType);
        }
    }
}