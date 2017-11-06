using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using TMS3.Library.Entities;
using Microsoft.EntityFrameworkCore;
using TMS3.Library.Interfaces;
using Microsoft.Extensions.Logging;

namespace TMS3.Library.Repositories
{
    /// <summary>
    /// The GenericRepository allows generic crud operations to take place in a default DbContext or one specified in the constructor.
    /// </summary>
    /// <typeparam name="T">The Type of entity that will be acted upon</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields
        private bool _validate;
        private ILogger<TMSContext> _logger;

        /// <summary>
        /// the DbContext to use for operations
        /// </summary>
        private DbContext _ctx;
        
        #endregion

        /// <summary>
        /// Default constructor creating a new DbContext and setting Autosave to true
        /// </summary>
        public Repository(TMSContext ctx,ILogger<TMSContext> logger)
        {
            _logger = logger;
            _ctx = ctx;
            Autosave = true;
        }


     
        /// <summary>
        /// Gets All items of Type T from the data store
        /// </summary>
        /// <returns>IEnumerable of the specified Type/></returns>
        public RepositoryResultList<T> GetAll()
        {
            RepositoryResultList<T> result = new RepositoryResultList<T>(); 
            try
            {
                result.Entities = _ctx.Set<T>().AsEnumerable();
                result.NoErrors = true;
            }
            catch (Exception ex)
            {
                // LogError(ex);
                _logger.LogError($"Error in Repository {ex}");
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

        /// <summary>
        /// Gets all of T from the data store
        /// </summary>
        /// <param name="includes">A list of property names to return in the object graph</param>
        /// <returns>RepositoryReslutList</returns>
        public RepositoryResultList<T> GetAll(params string[] includes)
        {
            RepositoryResultList<T> result = new RepositoryResultList<T>();

            try
            {
                var query = _ctx.Set<T>().Where(t => true);
                foreach (string include in includes)
                {
                    query = (IQueryable<T>)query.Include(include);
                }
                result.Entities = query.ToList();
                result.NoErrors = true;
            }
            catch (Exception ex)
            {
             //   LogError(ex);
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

 
        /// <summary>
        /// Performs a find on the repository given the specified Type and Filter expression (this will come from the FilterStore.FilterForUser
        /// method or a simple lambda expression
        /// </summary>
        /// <param name="filter">the Expression to use to filter objects from the data store</param>
        /// <returns>RepositoryResultList</returns>
        public RepositoryResultList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            RepositoryResultList<T> result = new RepositoryResultList<T>();

            try
            {
                result.Entities = _ctx.Set<T>().Where(filter.Compile());
                result.NoErrors = true;
            }
            catch (Exception ex)
            {
               // LogError(ex);
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

        /// <summary>
        /// Performs a find on the repository given the specified Type and Filter expression (this will come from the FilterStore.FilterForUser
        /// method or a simple lambda expression
        /// </summary>
        /// <param name="filter">the Expression to use to filter objects from the data store</param>
        /// <param name="includes">a params string array of property names that will be included in the resulting object graph for each item</param>
        /// <returns>RepositoryResultList</returns>
        public RepositoryResultList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> filter, params string[] includes)
        {
            RepositoryResultList<T> result = new RepositoryResultList<T>();

            try
            {
                var query = _ctx.Set<T>().Where(t => true);
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
                result.Entities = query.Where(filter.Compile());
                result.NoErrors = true;
            }
            catch (Exception ex)
            {
               // LogError(ex);
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

       
        /// <summary>
        /// Returns a single entity matching the filter provided
        /// </summary>
        /// <param name="filter">The Expression used to filter objects from the data store</param>
        /// <returns>RepositoryResultList</returns>
        public RepositoryResultSingle<T> Single(Expression<Func<T, bool>> filter)
        {
            RepositoryResultSingle<T> result = new RepositoryResultSingle<T>();

            try
            {
                result.Entity = _ctx.Set<T>().SingleOrDefault(filter);
                result.NoErrors = true;
            }
            catch (Exception ex)
            {                
              //  LogError(ex);
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

        /// <summary>
        /// Returns total records for entity filter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <returns>Total record count</returns>
        public int GetRecordCount(Expression<Func<T, bool>> filter)
        {
            var query = _ctx.Set<T>().Where(t => true);
            
            query = query.Where(filter.Compile()).AsQueryable();
            int totalRecords = query.Count();

            return totalRecords;
        }

        /// <summary>
        /// Returns total records for entity.
        /// </summary>
        /// <returns>Total record count.</returns>
        public int GetRecordCount()
        {
            return _ctx.Set<T>().Count();
        }

        /// <summary>
        /// Returns a single entity matching the filter provided
        /// </summary>
        /// <param name="filter">The Expression used to filter objects from the data store</param>
        /// <param name="includes">a parameter list of property names to include in each item in the returned entity object graph</param>
        /// <returns>RepositoryResultList</returns>
        public RepositoryResultSingle<T> Single(Expression<Func<T, bool>> filter, params string[] includes)
        {
            RepositoryResultSingle<T> result = new RepositoryResultSingle<T>();

            try
            {
                var query = _ctx.Set<T>().Where(t => true);
                foreach (string include in includes)    
                {
                    query = query.Include(include);
                }
                result.Entity = query.SingleOrDefault(filter.Compile());

                result.NoErrors = true;
            }
            catch (Exception ex)
            {
              //  LogError(ex);
                result.NoErrors = false;
                result.Message = ex.GetBaseException().Message;
            }

            return result;
        }

        /// <summary>
        /// Adds an item of T to the DbContext
        /// </summary>
        /// <param name="item">the item to add</param>
        public RepositoryResult Add(T item, bool throwException = true)
        {
            var result = new RepositoryResult();

            try
            {
                var set = _ctx.Set<T>();
                set.Add(item);
                _ctx.Entry<T>(item).State = EntityState.Added;
                if (Autosave)
                {
                    _ctx.SaveChanges();
                }
                result.NoErrors = true;
            }            
            catch (Exception ex)
            {
             //   LogError(ex);

                if (throwException)
                {
                    throw ex;
                }

                result.Message = ex.GetBaseException().Message;
                result.NoErrors = false;
            }

            return result;
        }

        /// <summary>
        /// Attaches and updates the item in the DbContext
        /// </summary>
        /// <param name="item">the item to update</param>
        public RepositoryResult Update(T item, bool throwException = true)
        {
            var result = new RepositoryResult();

            try
            {
                var set = _ctx.Set<T>();
                set.Attach(item);
                _ctx.Entry<T>(item).State = EntityState.Modified;
                if (Autosave)
                {
                    _ctx.SaveChanges();
                }                
                result.NoErrors = true;
            }           
            catch (Exception ex)
            {
               // LogError(ex);

                if (throwException)
                {
                    throw ex;//new RepositoryException(ex.Message, ex);
                }

                result.Message = ex.GetBaseException().Message;
                result.NoErrors = false;
            }

            return result;
        }

        /// <summary>
        /// Deletes the item from the DbContext
        /// </summary>
        /// <param name="item">the item to delete</param>
        public RepositoryResult Delete(T item, bool throwException = true)
        {
            var result = new RepositoryResult();

            try
            {
                var set = _ctx.Set<T>();                
                var existing = set.Attach(item);
                var r=set.Attach(item);
                if (existing != null)
                {                    
                    _ctx.Set<T>().Remove(item);
                }

                if (Autosave)
                {
                    _ctx.SaveChanges();
                }
                result.NoErrors = true;
            }            
            catch (Exception ex)
            {
               // LogError(ex);

                if (throwException)
                {
                    throw ex;
                }

                result.Message = ex.GetBaseException().Message;
                result.NoErrors = false;
            }

            return result;
        }

        /// <summary>
        /// disposes of the context
        /// </summary>
        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public IEnumerable<T> GetQueryable()
        {
            return _ctx.Set<T>().AsQueryable<T>();
        }

        /// <summary>
        /// Gets All items of Type T from the data store
        /// </summary>
        /// <returns>IEnumerable of the specified Type/></returns>
        public IEnumerable<T> GetAllEntity()
        {
            return _ctx.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAllEntity(params string[] includes)
        {
            var query = _ctx.Set<T>().Where(t => true);
            foreach (string include in includes)
            {
                query = (IQueryable<T>)query.Include(include);
            }
            return query.AsEnumerable();
        }

        /// <summary>
        /// Performs a find on the repository given the specified Type and Filter expression (this will come from the FilterStore.FilterForUser
        /// method or a simple lambda expression
        /// </summary>
        /// <param name="filter">the Expression to use to filter objects from the data store</param>
        /// <returns></returns>
        public IEnumerable<T> FindEntity(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _ctx.Set<T>().Where(filter.Compile()).AsEnumerable();
        }

        /// <summary>
        /// Performs a find, including sub objects
        /// </summary>
        /// <param name="filter">The Expression to use to filter the entities</param>
        /// <param name="includes">the sub-objects to include (by property name)</param>
        /// <returns></returns>
        public IEnumerable<T> FindEntity(Expression<Func<T, bool>> filter, params string[] includes)
        {
            var query = _ctx.Set<T>().Where(t => true);
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(filter.Compile());

        }

        /// <summary>
        /// returns a single entity based on the expression
        /// </summary>
        /// <param name="filter">the expression used to filter to a single entity</param>
        /// <returns>T</returns>
        T IRepository<T>.SingleEntity(Expression<Func<T, bool>> filter)
        {
            return _ctx.Set<T>().SingleOrDefault(filter);
        }

        /// <summary>
        /// returns a single entity based on the expression
        /// </summary>
        /// <param name="filter">the expression used to filter to a single entity</param>
        /// <param name="includes">the sub objects to include (by property name)</param>
        /// <returns>T</returns>
        T IRepository<T>.SingleEntity(Expression<Func<T, bool>> filter, params string[] includes)
        {
            var query = _ctx.Set<T>().Where(filter);
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Determines whether to call ctx.SaveChanges() on completion of an action.  Typically, if you are calling this as a standalone
        /// and not part of a unit of work, autosave will be true.  However, if used in a GenericUnitOfWork, then Autosave should be false
        /// to allow the GenericUnitOfWork to perform the save on the context that it passes to this class.
        /// </summary>
        public bool Autosave { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether entity if validated before saving.
        /// </summary>
        /// <value><c>true</c> if validating; otherwise, <c>false</c>.</value>
        public bool Validate
        {
            get
            {
                return _validate;
            }
            set
            {
                if (this._ctx != null)
                {
                    _validate = value;
                   // this._ctx.Configuration.ValidateOnSaveEnabled = value;
                }
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>The data context.</value>
        public DbContext Context
        {
            get
            {
                return _ctx;
            }
        }

        //public IAppLog AppLogger { get; set; }

        public IEnumerable<string> LogCategories { get; set; }

        //protected virtual void LogError(Exception ex)
        //{
        //    if (AppLogger != null)
        //    {
        //        var msg = ex.ToString() + "\r\n";

        //        msg += "\r\n   --- Begin stack trace leading to repository---\r\n";
        //        msg += string.Join("\r\n", Environment.StackTrace.Split('\n').Skip(3).Take(20).ToArray());
        //        msg += "\r\n   ...";
        //        msg += "\r\n   --- End stack trace leading to repository ---\r\n";

        //        AppLogger.LogError(LogCategories, msg);
        //    }
        //}

        //protected virtual void LogTrace(string message, string[] insertions)
        //{
        //    if (AppLogger != null)
        //    {
        //        AppLogger.LogInformation(LogCategories, message, insertions);
        //    }
        //}

        //protected virtual void LogSql(string info)
        //{
        //    if (AppLogger != null)
        //    {
        //        AppLogger.LogInformation(AppLog.SqlCategory, info);
        //    }
        //}

        public static bool TestDatabaseConnection(bool throwException)
        {
            //var entities = new DbContext();

            //try
            //{   
            //    // make any query to test db connection
            //    entities.Set<Activity>().Count();
            //}
            //catch (Exception)
            //{
            //    if (throwException)
            //        throw;

            //    return false;
            //}

            return true;
        }

    }
}
