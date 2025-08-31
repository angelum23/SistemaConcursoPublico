using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Application.Base;

public class AplicBase<T>(IServBase<T> service) : IAplicBase<T> where T : IEntidadeBase
{
    public List<T> Get() => service.Get();

    public Task<T> FindAsync(int id) => service.FindAsync(id);

    public Task<int> RemoveAsync(int id) => service.RemoveAsync(id);
    
    public Task<T> SaveAsync(T entity) => service.SaveAsync(entity);
}