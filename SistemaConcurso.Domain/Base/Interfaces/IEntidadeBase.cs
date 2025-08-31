namespace SistemaConcurso.Domain.Base.Interfaces;

public interface IEntidadeBase
{
    public int Id { get; set; }
    public bool Removido { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
}