using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using System.Data.Entity;

using batteryfilms.Domain.Abstract;

using batteryfilms.Domain.Concrete;
using batteryfilms.MVC.Infrastructure.Abstract;
using batteryfilms.MVC.Infrastructure.Concrete;
using batteryfilms.Domain.EFContexts.EFCF;


namespace batteryfilms.MVC.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType ==null ? null:(IController)ninjectKernel.Get(controllerType);
        }

        public void AddBindings()
        {/*
            Mock<IClipRepository> mock = new Mock<IClipRepository>();
            mock.Setup(m => m.Clips).Returns(new List<Clip>
            {
              
                new Clip{   Id=1, 
                            Title = "two",
                            url = "http://player.vimeo.com/video/24421089?title=0&amp;byline=0&amp;portrait=0;"},
                new Clip{   Id=2, 
                            Title = "three",
                            url = "http://player.vimeo.com/video/24421089?title=0&amp;byline=0&amp;portrait=0;"},
                new Clip{   Id=3, 
                            Title = "four",
                            url = "http://player.vimeo.com/video/24421089?title=0&amp;byline=0&amp;portrait=0;"},
                new Clip{   Id=4, 
                            Title = "five",
                            url = "http://player.vimeo.com/video/24421089?title=0&amp;byline=0&amp;portrait=0;"}
            }.AsQueryable());
            */
            ninjectKernel.Bind<IRepository>().To<ImplIRep_EFCFContext>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
           
        }

    }
}