using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MonoProject.Model;
using MonoProject.Model.Interfaces;
using MonoProject.Repository;
using MonoProject.Repository.Common;

namespace MonoProject.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private ProjectDbContext context = new ProjectDbContext();
        private IGenericRepository<IVehicleMakeEntity> makeRepository;
        private IGenericRepository<IVehicleModelEntity> modelRepository;

        public IGenericRepository<IVehicleMakeEntity> MakeRepository
        {
            get
            {
                if (this.makeRepository == null)
                {
                    this.makeRepository = new GenericRepository<IVehicleMakeEntity>(context);
                }
                return makeRepository;
            }
        }

        public IGenericRepository<IVehicleModelEntity> ModelRepository
        {
            get
            {
                if (this.modelRepository == null)
                {
                    this.modelRepository = new GenericRepository<IVehicleModelEntity>(context);
                }
                return modelRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
