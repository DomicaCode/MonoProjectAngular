using MonoProject.Model;
using MonoProject.Model.Interfaces;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<IVehicleMakeEntity> MakeRepository { get; }
        IGenericRepository<IVehicleModelEntity> ModelRepository { get; }
    }
}
