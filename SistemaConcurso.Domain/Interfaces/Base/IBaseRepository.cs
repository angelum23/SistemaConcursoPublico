using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Interfaces.DependencyInjection;

namespace SistemaConcurso.Domain.Interfaces.Base;

public interface IBaseRepository<T> : ISingletonDependency where T : IBaseEntity
{
    /// <summary>
    /// Retrieves an IQueryable&lt;T&gt; representing a queryable collection of entities of type T.
    /// IQueryable&lt;T&gt; is an interface in LINQ that enables building and executing queries against data sources (e.g., databases) with deferred execution,
    /// allowing operations like filtering, sorting, and projection to be composed before materialization.
    /// </summary>
    /// <typeparam name="T">The type of entities in the collection.</typeparam>
    /// <returns>An IQueryable&lt;T&gt; instance for querying the data source.</returns>
    IQueryable<T> Get();
    
    /// <summary>
    /// Adds an entity of type T to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <remarks>
    /// Sets the date of creation to the current date and time.
    /// </remarks>
    Task<T> AddAsync(T entity);
    
    /// <summary>
    /// Removes the entity with the specified <paramref name="id"/> from the repository.
    /// </summary>
    /// <param name="id">The id of the entity to remove.</param>
    /// <remarks>
    /// Sets the <see cref="IBaseEntity.Removido"/> property to <c>true</c> instead of actually removing the entity from the collection.
    /// </remarks>
    Task<T> RemoveAsync(int id);
    
    /// <summary>
    /// Removes the entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    /// <remarks>
    /// Sets the <see cref="IBaseEntity.Removido"/> property to <c>true</c> instead of actually removing the entity from the collection.
    /// </remarks>
    T Remove(T entity);
    
    /// <summary>
    /// Updates the entity with the specified <paramref name="id"/> in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <remarks>
    /// Sets the <see cref="IBaseEntity.DataAtualizacao"/> property to the current date and time.
    /// </remarks>
    T Update(T entity);
    
    /// <summary>
    /// Finds an entity with the specified <paramref name="id"/> in the repository.
    /// </summary>
    /// <param name="id">The id of the entity to find.</param>
    /// <returns>The found entity, or throws an exception if it is not found or has been removed.</returns>
    Task<T> FindAsync(int id);
}