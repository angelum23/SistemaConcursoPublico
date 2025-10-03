using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class JobRoles : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    
    [ForeignKey("Exam")]
    public int IdExam { get; set; }
    public Exams Exam { get; set; }
}