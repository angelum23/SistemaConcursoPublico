using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class Modules : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public int IdRoadmap { get; set; }
    public Roadmaps? Roadmap { get; set; }
    
    public List<Lessons> Lessons { get; set; } = [];
    
    public List<ModuleAssessment> ModuleAssessment { get; set; } = [];
}