using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Apartments_API.Repository
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Returns all objects from the database
        /// </summary>
        /// <returns>Found objects</returns>
        IEnumerable<T> FindAll();
        
        /// <summary>
        /// Returns all objects filtered by given expression
        /// </summary>
        /// <param name="expression">Filtering expression</param>
        /// <returns>Filtered objects list</returns>
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Updates selected object
        /// </summary>
        /// <param name="entity">Updated object</param>
        void Update(T entity);
        
        /// <summary>
        /// Deletes selected object
        /// </summary>
        /// <param name="entity">Object to delete</param>
        void Delete(T entity);
    }
}