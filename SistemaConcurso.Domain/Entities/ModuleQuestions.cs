namespace SistemaConcurso.Domain.Entities;

public class ModuleQuestions
{
    public int IdModule { get; set; }
    public int IdQuestion { get; set; }
    
    public Modules? Modules { get; set; }
    public Questions? Questions { get; set; }
}