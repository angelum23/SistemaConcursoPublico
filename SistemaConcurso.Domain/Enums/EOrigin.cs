using System.ComponentModel;

namespace SistemaConcurso.Domain.Enums;

public enum EOrigin
{
    [Description("Assessment")] 
    Assessment = 1,
    
    [Description("Module")] 
    Module = 2,
    
    [Description("Lesson")] 
    Lesson = 3,
}