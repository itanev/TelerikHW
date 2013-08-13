﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using DataLayer;
using RipositoriesLayer;
using ServicesLayer.Controllers;

namespace ServicesLayer.Tests
{
    class TestPlacesDependencyResolver<T> : IDependencyResolver
    {
        private IRepsitory<T> repository;

        public IRepsitory<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController();
            }
            else if (serviceType == typeof(StudentsController))
            {
            }
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
