using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TMS3.Library.Repositories;

namespace TMS3.Library.Interfaces
{
    /// <summary>
    /// The interface that all of our data repositories have in common.
    /// </summary>
    /// <typeparam name="T">The Type of the repository</typeparam>
    public interface IRepository<T> : IDisposable
    {
        
        /// property to determine whether or not to validate entities on save (in implementation this should default to true)
        /// </summary>
        bool Validate { get; set; }
        /// <summary>
        /// Gets all of a particular entity
        /// </summary>
        /// <returns>RepositoryResultList of matching entities</returns>
        RepositoryResultList<T> GetAll();
        /// <summary>
        /// Gets all of a particular entity including sub objects defined by the includes
        /// </summary>
        /// <param name="includes">a string array of Property names for which to fetch entities related to the object</param>
        /// <returns>RepositoryResultList of matching entities</returns>
        RepositoryResultList<T> GetAll(params string[] includes);
       
        

        /// <summary>
        /// Gets a set of entities based on the filter expression
        /// </summary>
        /// <param name="filter">The expression used to filter the entities</param>
        /// <returns>RepositoryResultList of matching entities</returns>
        RepositoryResultList<T> Find(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Gets a set of entities based on the filter expression
        /// </summary>
        /// <param name="filter">The expression used to filter the entities</param>
        /// <param name="includes">a string array of Property names for which to fetch entities related to the object</param>
        /// <returns>RepositoryResultList of matching entities</returns>
        RepositoryResultList<T> Find(Expression<Func<T, bool>> filter, params string[] includes);
       
     
        /// <summary>
        /// Returns a single entity based on the expression
        /// </summary>
        /// <param name="filter">The Expression to use for finding a single entity</param>
        /// <returns>T</returns>
        RepositoryResultSingle<T> Single(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Returns a single entity based on the expression
        /// </summary>
        /// <param name="filter">The Expression to use for finding a single entity</param>
        /// <param name="includes">a string array of Property names for which to fetch entities related to the object</param>
        /// <returns></returns>
        RepositoryResultSingle<T> Single(Expression<Func<T, bool>> filter, params string[] includes);

        /// <summary>
        /// Returns total records for entity filter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <returns>Total record count</returns>
        int GetRecordCount(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Returns total records for entity.
        /// </summary>
        /// <returns>Total record count.</returns>
        int GetRecordCount();

        /// <summary>
        /// Adds an entity to a datacontext
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns>A RepositoryResult</returns>
        RepositoryResult Add(T entity, bool throwException = true);
        /// <summary>
        /// Modifies an entity in a datacontext
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns>A RepositoryResult</returns>
        RepositoryResult Update(T entity, bool throwException = true);
        /// <summary>
        /// Deletes an entity from a datacontext
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        /// <returns>A RepositoryResult</returns>
        RepositoryResult Delete(T entity, bool throwException = true);

        /// <summary>
        /// Gets all of an entity
        /// </summary>
        /// <returns>IEnumerable T"/></returns>
        IEnumerable<T> GetAllEntity();
        /// <summary>
        /// Finds a subset of an entity based on the supplied filter
        /// </summary>
        /// <param name="filter">The Expression to use to filter the entities</param>
        /// <returns>IEnumerable T</returns>
        IEnumerable<T> FindEntity(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Finds a subset of an entity based on the supplied filter
        /// </summary>
        /// <param name="filter">The Expression to use to filter the entities</param>
        /// <param name="includes">a string array of Property names for which to fetch entities related to the object</param>
        /// <returns>IEnumerable T</returns>
        IEnumerable<T> FindEntity(Expression<Func<T, bool>> filter, params string[] includes);
        /// <summary>
        /// Finds a single entity based on the supplied filter
        /// </summary>
        /// <param name="filter">The Expression to use to filter to a single entity</param>
        /// <returns>T</returns>
        T SingleEntity(Expression<Func<T, bool>> filter);
        /// <summary>
        /// Finds a single entity based on the supplied filter
        /// </summary>
        /// <param name="filter">The Expression to use to filter to a single entity</param>
        /// <param name="includes">a string array of Property names for which to fetch entities related to the object</param>
        /// <returns>T</returns>
        T SingleEntity(Expression<Func<T, bool>> filter, params string[] includes);

        bool Autosave { get; set; }

        void SaveChanges();

        IEnumerable<T> GetQueryable();

        DbContext Context
        {
            get;
        }

        ///// <summary>
        ///// The logger to log to if set
        ///// </summary>
        //IAppLog AppLogger { get; set; }

        IEnumerable<string> LogCategories { get; set; }
    }
}
