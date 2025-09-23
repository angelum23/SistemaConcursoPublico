namespace SistemaConcurso.Domain.Interfaces.Base;

public interface IPagination
{
    public int Skip { get; set; }
    public int Take { get; set; }
}