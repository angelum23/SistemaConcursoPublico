using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.Domain.Base;

public class ServBase<T>(IBaseRepository<T> repository) : IBaseService<T> where T : IBaseEntity
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