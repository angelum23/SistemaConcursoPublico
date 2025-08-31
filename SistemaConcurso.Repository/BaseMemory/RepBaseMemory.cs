using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Repository.BaseMemory;

public class RepBaseMemory<T> : IRepBase<T> where T : IEntidadeBase
{
    private List<T> _dataBase = [];

    public IQueryable<T> Get() => _dataBase.AsQueryable();
    
    public Task<T> AddAsync(T entity)
    {
        entity.DataCadastro = DateTime.Now;
        _dataBase.Add(entity);
        return Task.FromResult(entity);
    }
    
    public async Task<int> RemoveAsync(int id)
    {
        var entity = await FindAsync(id);
        if (entity == null || entity.Removido)
        {
            throw new Exception("Register not fount!");
        }
        
        entity.Removido = true;
        return entity.Id;
    }
    
    public async Task<T> UpdateAsync(T entity)
    {
        var register = await FindAsync(entity.Id);
        register.DataAtualizacao = DateTime.Now;
        
        var index = _dataBase.FindIndex(x => x.Id == entity.Id);
        _dataBase[index] = entity;
        return entity;
    }
    
    public Task<T> FindAsync(int id)
    {
        var entity = _dataBase.Find(x => x.Id == id);
        if (entity == null || entity.Removido)
        {
            throw new Exception("Register not fount!");
        }

        return Task.FromResult(entity);
    }
}