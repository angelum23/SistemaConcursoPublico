namespace SistemaConcurso.Domain.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Asynchronously saves all changes made in this unit of work to the underlying database.
    /// </summary>
    /// <param name="ct">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous save operation. The task result contains the
    /// number of state entries written to the database.
    /// </returns>
    Task<int> CommitAsync(CancellationToken ct = default);
    
    /// <summary>
    /// Saves all changes made in this unit of work to the underlying database synchronously.
    /// </summary>
    /// <param name="ct">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The number of state entries written to the database.</returns>
    int Commit(CancellationToken ct = default);
}
