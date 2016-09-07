using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LehaProjectMVC.Core.Interfaces
{
    public interface IDataContext
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>The database.</value>
        Database Database { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Gets the change tracker.
        /// </summary>
        /// <value>The change tracker.</value>
        DbChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Rows affected</returns>
        int SaveChanges();

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>The entry of entity</returns>
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <returns>The db set of T</returns>
        DbSet<T> Set<T>() where T : class;
    }
}
