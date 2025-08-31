using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Domain.Base;

public class ServBase<T>(IRepBase<T> repository) : IServBase<T> where T : IEntidadeBase
{
    public List<T> Get() => repository.Get().ToList();

    public Task<T> FindAsync(int id) => repository.FindAsync(id);

    public Task<int> RemoveAsync(int id) => repository.RemoveAsync(id);
    
    public Task<T> SaveAsync(T entity)
    {
        return entity.Id > 0 
            ? repository.UpdateAsync(entity) 
            : repository.AddAsync(entity);
    }
}