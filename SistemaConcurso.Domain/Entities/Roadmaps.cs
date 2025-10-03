using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class Roadmaps : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    
    [ForeignKey("Exam")]
    public int IdExam { get; set; }
    public Exams Exam { get; set; }
    
    [ForeignKey("SelectedJobRole")]
    public int? IdSelectedJobRole { get; set; }
    public JobRoles? SelectedJobRole { get; set; }
    
    public List<Modules> Modules { get; set; } = [];
    public List<RoadmapAssessments> RoadmapAssessment { get; set; } = [];
}