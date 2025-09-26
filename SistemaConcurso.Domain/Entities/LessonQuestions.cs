namespace SistemaConcurso.Domain.Entities;

public class LessonQuestions
{
    public int IdLesson { get; set; }
    public int IdQuestion { get; set; }
    
    public Lessons? Lessons { get; set; }
    public Questions? Questions { get; set; }
}