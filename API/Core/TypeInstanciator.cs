using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;

namespace API.Core
{
    public class TypeInstanciator
    {
        private readonly Dictionary<Type, Func<IHttpController>> _mappings = new Dictionary<Type, Func<IHttpController>>();

        public void AddCreator<T>(Func<T> creator) where T : IHttpController
        {
            _mappings.Add(typeof(T), () => creator());
        }

        public bool Contains(Type controllerType)
        {
            return _mappings.ContainsKey(controllerType);
        }

        public IHttpController Create(Type controllerType)
        {
            return _mappings[controllerType]();
        }
    }
}