using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;

namespace SistemaConcurso.Domain.Entities;

public class Lessons : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; private set; }
    
    public int IdModule { get; set; }
    public Modules? Module { get; set; }

    public List<LessonAssessment> LessonAssessment { get; set; } = [];

    #region Rules
    
    public void MarkDone()
    {
        if (Done) throw new RuleException(EException.LessonAlreadyDone);
        Done = true;
    }
    
    public void MarkTodo()
    {
        if (!Done) throw new RuleException(EException.LessonAlreadyTodo);
        Done = false;
    }
    
    #endregion
}