using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class Lesson : BaseEntity
{
    public int IdModule { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}