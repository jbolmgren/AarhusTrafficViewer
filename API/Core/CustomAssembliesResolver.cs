using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace API.Core
{
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