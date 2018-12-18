using MonoProject.Service.Common;
using MonoProject.Service;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonoProject.Repository.Common;
using MonoProject.DAL;
using MonoProject.Model;

namespace MonoProject.WebAPI.Controllers.NinjectTest
{
    public class NinjectTest : NinjectModule
    {

        public override void Load()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IGenericRepository<VehicleMakeEntity>>().To<GenericRepository<VehicleMakeEntity>>();
            kernel.Bind<IGenericRepository<VehicleModelEntity>>().To<GenericRepository<VehicleModelEntity>>();
            kernel.Bind<IVehicleService>().To<VehicleService>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            
        }
    }
}
