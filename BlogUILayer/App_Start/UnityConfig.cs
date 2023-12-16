using BlogDAL;
using BlogDAL.Authentication;
using BlogDAL.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BlogUILayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IEmpRepository, EmpRepository>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IBlogReposotiry,BlogRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}