using LehaProjectMVC.Core.Entities.Base;
using System.Linq;
using LehaProjectMVC.Core.Interfaces;
using LehaProjectMVC.Core.Interfaces.Repositories.Base;
using System.Data.Entity;

namespace LehaProjectMVC.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Entity framework db context
        /// </summary>
        protected readonly IDataContext dataContext;

        /// <summary>
        /// Gets the current set.
        /// </summary>
        /// <value>The current set.</value>
        private DbSet<T> CurrentSet
        {
            get
            {
                return this.dataContext.Set<T>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="context">Nhibernate session</param>
        public Repository(IDataContext context)
        {
            this.dataContext = context;
        }

        /// <summary>
        /// Get query for all entities
        /// </summary>
        /// <returns>Query for all entities</returns>
        public IQueryable<T> GetAll()
        {
            return this.CurrentSet.AsQueryable();
        }

        /// <summary>
        /// Add entity to data base
        /// </summary>
        /// <param name="entity">Entity for add</param>
        /// <returns>Saved entity</returns>
        public T Add(T entity)
        {
            this.CurrentSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Edit entity in data base
        /// </summary>
        /// <param name="entity">Entity to edit</param>
        public void Edit(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete entity from data base
        /// </summary>
        /// <param name="entity">Entity for delete</param>
        public void Delete(T entity)
        {
            this.CurrentSet.Remove(entity);
        }

        public void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <returns>Entity by id</returns>
        public T GetById(long id)
        {
            return this.CurrentSet.Find(id);
        }

        /// <summary>
        /// Update entity in data base
        /// </summary>
        /// <param name="entity">Entity for update</param>
        public void Update(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
