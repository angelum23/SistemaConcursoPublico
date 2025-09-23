using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.Domain.Base;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : IBaseEntity
{
    public List<T> Get(IPagination pagination) => repository.Get().Skip(pagination.Skip).Take(pagination.Take).ToList();

    public Task<T> FindAsync(int id) => repository.FindAsync(id);

    public Task<T> RemoveAsync(int id) => repository.RemoveAsync(id);
    
    public Task<T> SaveAsync(T entity)
    {
        return entity.Id > 0 
            ? Task.FromResult(repository.Update(entity)) 
            : repository.AddAsync(entity);
    }
}