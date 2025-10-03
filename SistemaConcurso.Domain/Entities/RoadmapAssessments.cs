using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class RoadmapAssessments : BaseEntity
{
    public int RetriesCount { get; set; }
    
    [ForeignKey("Roadmap")]
    public int IdRoadmap { get; set; }
    public Roadmaps? Roadmap { get; set; }
    public List<Questions> Questions { get; set; } = [];
}