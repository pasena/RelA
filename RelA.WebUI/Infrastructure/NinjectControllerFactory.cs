using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using RelA.Domain.Abstract;
using RelA.Domain.Concrete;

namespace RelA.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel = null;

        public NinjectControllerFactory()
        {
            this.kernel = new StandardKernel();
            this.AddBinding();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }

        private void AddBinding()
        {
            this.kernel.Bind<IUserRepository>().To<UserRepository>();
            this.kernel.Bind<IProjectRepository>().To<ProjectRepository>();
        }
    }
}
