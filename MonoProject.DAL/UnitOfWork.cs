using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MonoProject.Model;
using MonoProject.Repository.Common;

namespace MonoProject.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private ProjectDbContext context = new ProjectDbContext();
        private IGenericRepository<VehicleMakeEntity> makeRepository;
        private IGenericRepository<VehicleModelEntity> modelRepository;

        public IGenericRepository<VehicleMakeEntity> MakeRepository
        {
            get
            {
                if (this.makeRepository == null)
                {
                    this.makeRepository = new GenericRepository<VehicleMakeEntity>(context);
                }
                return makeRepository;
            }
        }

        public IGenericRepository<VehicleModelEntity> ModelRepository
        {
            get
            {
                if (this.modelRepository == null)
                {
                    this.modelRepository = new GenericRepository<VehicleModelEntity>(context);
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
