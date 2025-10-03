using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.Application.Base;

public class BaseApplication<T>(IBaseService<T> service, IUnitOfWork uow) : IBaseApplication<T> where T : IBaseEntity
{
    public Task<int> CommitAsync() => uow.CommitAsync();
    public int Commit() => uow.Commit();
    public List<T> Get(IPagination pagination) => service.Get(pagination);

    public Task<T> FindAsync(int id) => service.FindAsync(id);

    public Task<T> RemoveAsync(int id) => service.RemoveAsync(id);
    
    public Task<T> SaveAsync(T entity) => service.SaveAsync(entity);
}