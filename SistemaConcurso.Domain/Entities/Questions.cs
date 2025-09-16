using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;

namespace SistemaConcurso.Domain.Entities;

public class Questions : BaseEntity
{
    public int IdAssessment { get; set; }
    public string Question { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public OptionChar CorrectOption { get; set; }
    public OptionChar SelectedOption { get; set; }
}