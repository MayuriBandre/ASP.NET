using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RegistrationForm
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private readonly DataAccess dataAccess;

        public CustomDependencyResolver(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(DataAccess) ? dataAccess : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new object[] { };
        }
    }

}