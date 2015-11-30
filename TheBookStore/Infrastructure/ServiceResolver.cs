using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using TheBookStore.Contracts;
using TheBookStore.Datastores;

namespace TheBookStore.Infrastructure
{
    public class ServiceResolver : IDependencyResolver
    {
        private IUnityOfWork _dataStore = new SampleDataStore();

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.BaseType == typeof(ApiController))
                return Activator.CreateInstance(serviceType, _dataStore);

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            
        }
    }
}