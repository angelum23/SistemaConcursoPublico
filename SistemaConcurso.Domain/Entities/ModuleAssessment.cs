using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class ModuleAssessment : BaseEntity
{
    public int IdModule { get; set; }
    
    public Modules? Module { get; set; }
    public List<Questions> Questions { get; set; } = [];
}