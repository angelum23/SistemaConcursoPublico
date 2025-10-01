using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class Roadmaps : BaseEntity
{
    public string? Title { get; set; }
    
    public int IdExam { get; set; }
    public Exams Exam { get; set; }
    
    public int? IdSelectedJobRole { get; set; }
    public JobRoles? SelectedJobRole { get; set; }
    
    public List<Modules> Modules { get; set; } = [];
    public List<RoadmapAssessment> RoadmapAssessment { get; set; } = [];
}