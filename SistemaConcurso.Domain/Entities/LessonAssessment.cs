using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class LessonAssessment : BaseEntity
{
    public int RetriesCount { get; set; }
    
    public int IdLesson { get; set; }
    
    public Lessons? Lesson { get; set; }
    public List<Questions> Questions { get; set; } = [];
}