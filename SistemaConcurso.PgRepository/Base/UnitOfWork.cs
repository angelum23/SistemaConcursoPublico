using SistemaConcurso.Domain.Interfaces;

namespace SistemaConcurso.PgRepository.Base;

public class UnitOfWork(PgDbContext db) : IUnitOfWork
{
    public ValueTask DisposeAsync() => db.DisposeAsync();

    public Task<int> CommitAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);

    public int Commit(CancellationToken ct = default) => db.SaveChanges();
}