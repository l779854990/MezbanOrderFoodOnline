using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MezbanService.Implements
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Insert(entity);
            _unitOfWork.Complete();

            return entity;
        }
        public T InsertBase(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Insert(entity);

            return entity;
        }
        public List<T> InsertMulti(List<T> entity)
        {
            try
            {
                _repository.InsertMulti(entity);
                _unitOfWork.Complete();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _repository.Delete(entity);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(dynamic id)
        {
            return _repository.Delete(id);
        }

        public bool DeleteMulti(List<T> entity)
        {
            try
            {
                _repository.DeleteMulti(entity);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T GetById(long id)
        {
            return _repository.GetById(id);
        }
        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return _repository.Find(expression, includes);
        }
        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return _repository.FindAll(expression, includes);
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Update(entity);
            _unitOfWork.Complete();

            return entity;
        }

        public T UpdateBase(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Update(entity);

            return entity;
        }
    }
}
