using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;

namespace SistemaConcurso.Domain.Entities;

public class Questions : BaseEntity
{
    public string Question { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
 
    public int Order { get; set; }
    
    public EOptionChar CorrectEOption { get; set; }
    public EOptionChar? SelectedOption { get; set; }
    public bool IsCorrect => SelectedOption == CorrectEOption;
    
    public int? IdLessonAssessment { get; set; }
    public LessonAssessment? LessonAssessment { get; set; }
    
    public int? IdModuleAssessment { get; set; }
    public ModuleAssessment? ModuleAssessment { get; set; }
    
    public int? IdRoadmapAssessment { get; set; }
    public RoadmapAssessment? RoadmapAssessment { get; set; }
}