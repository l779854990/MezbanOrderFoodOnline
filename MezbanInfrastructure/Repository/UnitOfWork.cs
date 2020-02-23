using MezbanCommon.Heplers;
using MezbanData.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace MezbanInfrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MezbanAirKitchenEntities _context;
        private readonly Dictionary<Type, object> _repository;
        private bool _disposed;

        public UnitOfWork(MezbanAirKitchenEntities entities)
        {
            _context = entities;
            _context.Configuration.ProxyCreationEnabled = false;
            _repository = new Dictionary<Type, object>();
            _disposed = false;
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Function us to Get instance of a Object on Database
        /// </summary>
        /// <typeparam name="TEntity">Object is target</typeparam>
        /// <returns></returns>
        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            //Check if the Dictionary key contains the Model class
            if (_repository.Keys.Contains(typeof(TEntity)))
            {
                return _repository[typeof(TEntity)] as IBaseRepository<TEntity>;
            }
            // If the repository for that Model class doesn't exist, create it
            var repository = new BaseRepository<TEntity>(_context);

            _repository.Add(typeof(TEntity), repository);
            return repository;
        }

        /// <summary>
        /// Function use to Save all Object is changed into Database 
        /// </summary>
        public bool Complete()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbEntityValidationException e)
            {
                LoggerHelper.Logger.Error(e);
                var newException = new FormattedDbEntityValidationException(_context, e);
                throw new Exception(newException.Message);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                LoggerHelper.Logger.Error(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LoggerHelper.Logger.Error(ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        DbContextTransaction IUnitOfWork.BeginTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
