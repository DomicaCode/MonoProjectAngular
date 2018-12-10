using Data.Interfaces;
using Data.Repositories;
using Data.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Controllers.NinjectAutoFac_test
{
    public class NinjectTest : NinjectModule
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public override void Load()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IMakeRepository>().To<MakeRepository>();
            kernel.Bind<IModelRepository>().To<ModelRepository>();
            kernel.Bind<IVehicleService>().To<VehicleService>();
        }
    }
}
