using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.PgRepository.Base;

public class BaseRepository<T>(PgDbContext db) : IBaseRepository<T> where T : class, IBaseEntity
{
    private readonly PgDbContext _db = db;
    private readonly DbSet<T> _set = db.Set<T>();
    
    public IQueryable<T> Get()
    {
        return _set.AsQueryable();
    }
    
    public IQueryable<TEntity> Get<TEntity>() where TEntity : class
    {
        return _db.Set<TEntity>().AsQueryable();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        return entity;
    }
    
    public async Task<T> RemoveAsync(int id)
    {
        var reg = await _set.FindAsync(id)
                   ?? throw new RuleException(EException.RegisterNotFound);
        
        _set.Remove(reg);
        return reg;
    }
    
    public T Remove(T reg)
    {
        _set.Remove(reg);
        return reg;
    }

    public T Update(T entity)
    {
        _set.Update(entity);
        return entity;
    }

    public async Task<T> FindAsync(int id)
    {
        return await db.FindAsync<T>(id) 
               ?? throw new RuleException(EException.RegisterNotFound);
    }
}