using System.Linq;
using LehaProjectMVC.Core.Entities.Base;

namespace LehaProjectMVC.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Get query for all entities
        /// </summary>
        /// <returns>Query for all entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Add entity to data base
        /// </summary>
        /// <param name="entity">Entity for add</param>
        /// <returns>Saved entity</returns>
        T Add(T entity);

        /// <summary>
        /// Delete entity from data base
        /// </summary>
        /// <param name="entity">Entity for delete</param>
        void Delete(T entity);

        /// <summary>
        /// Edit entity in data base
        /// </summary>
        /// <param name="entity">Entity to edit</param>
        void Edit(T entity);

        /// <summary>
        /// Seve changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <returns>Entity by id</returns>
        T GetById(long id);

        /// <summary>
        /// Update entity in data base
        /// </summary>
        /// <param name="entity">Entity for update</param>
        void Update(T entity);
    }
}
