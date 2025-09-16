using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Application.Base;

public class BaseApplication<T>(IBaseService<T> service) : IBaseApplication<T> where T : IBaseEntity
{
    public List<T> Get() => service.Get();

    public Task<T> FindAsync(int id) => service.FindAsync(id);

    public Task<int> RemoveAsync(int id) => service.RemoveAsync(id);
    
    public Task<T> SaveAsync(T entity) => service.SaveAsync(entity);
}