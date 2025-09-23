using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.MemoryRepository;

public class BaseMemoryRepository<T> where T : IBaseEntity
{
    private List<T> _dataBase = [];

    public IQueryable<T> Get() => _dataBase.AsQueryable();
    
    public Task<T> AddAsync(T entity)
    {
        entity.RegisterDate = DateTime.Now;
        entity.Id = _dataBase.Count + 1;
        
        _dataBase.Add(entity);
        return Task.FromResult(entity);
    }
    
    public async Task<int> RemoveAsync(int id)
    {
        var entity = await FindAsync(id);
        if (entity == null)
        {
            throw new RuleException(EException.RegisterNotFound);
        }
        
        entity.Remove();
        return entity.Id;
    }

    public async Task<int> RestoreAsync(int id)
    {
        var entity = await FindAsync(id);
        if (entity == null)
        {
            throw new RuleException(EException.RegisterNotFound);
        }
        
        entity.Recover();
        return entity.Id;
    }
    
    public async Task<T> UpdateAsync(T entity)
    {
        var register = await FindAsync(entity.Id);
        register.LastUpdateDate = DateTime.Now;
        
        var index = _dataBase.FindIndex(x => x.Id == entity.Id);
        _dataBase[index] = entity;
        return entity;
    }
    
    public Task<T> FindAsync(int id)
    {
        var entity = _dataBase.Find(x => x.Id == id);
        if (entity == null || entity.Removed)
        {
            throw new RuleException(EException.RegisterNotFound);
        }

        return Task.FromResult(entity);
    }
}