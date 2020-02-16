using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MezbanInfrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CompleteAsync();

        /// <summary>
        /// Function us to Get instance of a Object on Database
        /// </summary>
        /// <typeparam name="TEntity">Object is target</typeparam>
        /// <returns></returns>
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        /// <summary>
        /// Function use to Save all Object is changed into Database 
        /// </summary>
        bool Complete();

        DbContextTransaction BeginTransaction();
    }
}
