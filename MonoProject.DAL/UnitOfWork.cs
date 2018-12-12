using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MonoProject.Model;

namespace MonoProject.DAL
{
    public class UnitOfWork : IDisposable
    {

        private ProjectDbContext context = new ProjectDbContext();
        private GenericRepository<VehicleMakeEntity> makeRepository;
        private GenericRepository<VehicleModelEntity> modelRepository;

        public GenericRepository<VehicleMakeEntity> MakeRepository
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

        public GenericRepository<VehicleModelEntity> ModelRepository
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
