namespace SistemaConcurso.Domain.Base.Interfaces;

public interface IBaseEntity
{
    public int Id { get; set; }
    public bool Removed { get; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public void Remove();
    public void Recover();
}