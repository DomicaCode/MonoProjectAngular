using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonoProject.Model;
using MonoProject.Model.Interfaces;
using MonoProject.Repository;
using MonoProject.Repository.Common;

namespace MonoProject.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectDbContext _dbContext;
        private bool _disposed;

        public bool Success { get; private set; }
        public string Message { get; private set; }

        public UnitOfWork(ProjectDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("DbContext");
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task<bool> Commit<T>(T entity) where T : class
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var dbEntityEntry = _dbContext.Entry(entity);

                    if (dbEntityEntry.State != EntityState.Detached)
                    {
                        dbEntityEntry.State = EntityState.Added;
                    }

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                    await DetachAll();


                    Success = true;
                    // Message = Info.OperationSuccess;
                }
                catch (DbUpdateException ex)
                {
                   // transaction.Rollback();
                    Message = string.Format(ex.ToString());
                }
                catch (Exception ex)
                {
                    Message = string.Format(ex.ToString());
                   // transaction.Rollback();
                }
            }

            return Success;
        }

        private async Task DetachAll()
        {
            foreach (var dbEntityEntry in _dbContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }


        protected virtual async Task Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }


        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
