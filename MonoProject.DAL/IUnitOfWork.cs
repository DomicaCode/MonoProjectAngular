using MonoProject.Model;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<VehicleMakeEntity> MakeRepository { get; }
        IGenericRepository<VehicleModelEntity> ModelRepository { get; }
    }
}
