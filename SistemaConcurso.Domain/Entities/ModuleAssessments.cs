using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class ModuleAssessments : BaseEntity
{
    public int RetriesCount { get; set; }
    
    [ForeignKey("Module")]
    public int IdModule { get; set; }
    public Modules? Module { get; set; }
    public List<Questions> Questions { get; set; } = [];
}