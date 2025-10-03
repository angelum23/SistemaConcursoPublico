using System.ComponentModel.DataAnnotations.Schema;
using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class LessonAssessments : BaseEntity
{
    public int RetriesCount { get; set; }
    
    [ForeignKey("Lesson")]
    public int IdLesson { get; set; }
    public Lessons? Lesson { get; set; }
    public List<Questions> Questions { get; set; } = [];
}