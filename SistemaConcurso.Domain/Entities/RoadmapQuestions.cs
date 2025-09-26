namespace SistemaConcurso.Domain.Entities;

public class RoadmapQuestions
{
    public int IdRoadmap { get; set; }
    public int IdQuestion { get; set; }
    
    public Roadmaps? Roadmaps { get; set; }
    public Questions? Questions { get; set; }
}