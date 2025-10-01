using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class RoadmapAssessment : BaseEntity
{
    public int RetriesCount { get; set; }
    
    public int IdRoadmap { get; set; }
    
    public Roadmaps? Roadmap { get; set; }
    public List<Questions> Questions { get; set; } = [];
}