using MonoProject.Model;
using MonoProject.Model.Interfaces;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {

        Task<bool> Commit<T>(T entity) where T : class;
    }
}
