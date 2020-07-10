using HcTechAssessmentRepo;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using Unity.Exceptions;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
using System;

namespace HCAssesmentAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMemberContext, MemberContext>();
            container.RegisterType<IMemberRepository, MemberRepository>(new InjectionConstructor(container.Resolve<IMemberContext>()));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }

    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}