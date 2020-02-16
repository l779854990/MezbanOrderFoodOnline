﻿using MezbanCommon;
using MezbanData.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MezbanInfrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IDbSet<T> Dbset;
        private readonly MezbanAirKitchenEntities _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public BaseRepository(MezbanAirKitchenEntities context)
        {
            _dbContext = context;
            _dbContext.Configuration.ProxyCreationEnabled = false;
            Dbset = context.Set<T>();
        }

        /// <summary>
        /// Function use to get Object flow Id
        /// </summary>
        /// <param name="id">Primary key of Table current</param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Get All list Object
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Dbset.AsQueryable();
        }

        /// <summary>
        /// Function use to Execute SQL Command Line
        /// </summary>
        /// <typeparam name="TEntity">Object is target</typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> ExecuteSql<TEntity>(string sql) where TEntity : class
        {
            return _dbContext.Database.SqlQuery<TEntity>(sql);
        }

        public int ExecuteSql(string sql)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// Function use in the case Query have condition
        /// </summary>
        /// <param name="filter">Condition of query</param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return Dbset.Where(filter);
        }

        /// <summary>
        /// Function use to Update Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public T Update(T entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Dbset.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Function use to Insert Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public T Insert(T entity)
        {
            Dbset.Add(entity);

            return entity;
        }

        public List<T> InsertMulti(List<T> entity)
        {
            foreach (var item in entity)
            {
                Dbset.Add(item);
            }
            return entity;
        }

        public List<T> UpdateMulti(List<T> listItem)
        {
            foreach (var item in listItem)
            {
                Update(item);
            }
            return listItem;
        }

        /// <summary>
        /// Function use to Remove Object in Database
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                var entry = _dbContext.Entry(entity);
                entry.State = EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(dynamic id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            Delete(entity);
            return true;
        }

        public bool DeleteMulti(List<T> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    Delete(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            query = query.Where(expression);
            return query.FirstOrDefault();
        }
        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.ToList();
        }

        public virtual IEnumerable<T> GetPaging(int page, int pageSize)
        {
            page = (page <= 0) ? 1 : page;
            pageSize = (pageSize <= 0) ? ContanstHelper.DEFAULT_PAGE_SIZE : pageSize;

            return Dbset.OrderByDescending(OrderByExtension.GetKeyField(typeof(T))).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public int GetTotalRecord()
        {
            return Dbset.Count();
        }

        public IEnumerable<T> GetPaging(int page, int pageSize, Expression<Func<T, bool>> expression)
        {
            page = (page <= 0) ? 1 : page;
            pageSize = (pageSize <= 0) ? ContanstHelper.DEFAULT_PAGE_SIZE : pageSize;

            return Dbset.Where(expression).OrderBy(OrderByExtension.GetKeyField(typeof(T))).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
