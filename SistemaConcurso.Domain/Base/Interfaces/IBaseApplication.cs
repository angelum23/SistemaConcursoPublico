namespace SistemaConcurso.Domain.Base.Interfaces;

public interface IBaseApplication<T>
{
    /// <summary>
    /// Gets a list of all entities.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    List<T> Get();
    
    /// <summary>
    /// Finds an entity with the specified <paramref name="id"/> in the repository.
    /// </summary>
    /// <param name="id">The id of the entity to find.</param>
    /// <returns>The found entity, or throws an exception if it is not found or has been removed.</returns>
    Task<T> FindAsync(int id);
    
    /// <summary>
    /// Saves an entity asynchronously, either creating or updating it
    /// as appropriate.
    /// </summary>
    /// <param name="entity">The entity to save.</param>
    /// <remarks>If the entity has an ID greater than 0, it will be updated.</remarks>
    /// <returns>The saved entity.</returns>
    Task<T> SaveAsync(T entity);
    
    /// <summary>
    /// Removes the entity with the specified <paramref name="id"/> from the repository.
    /// </summary>
    /// <param name="id">The id of the entity to remove.</param>
    /// <remarks>
    /// Sets the <see cref="IBaseEntity.Removido"/> property to <c>true</c> instead of actually removing the entity from the collection.
    /// </remarks>
    Task<int> RemoveAsync(int id);
}