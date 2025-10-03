using System.ComponentModel.DataAnnotations.Schema;
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
    
    public EOptionChar CorrectOption { get; set; }
    public EOptionChar? SelectedOption { get; set; }
    public bool IsDone => SelectedOption != null;
    public bool IsCorrect => SelectedOption == CorrectOption;
    
    public EOrigin Origin { get; set; }
    
    [ForeignKey("LessonAssessment")]
    public int? IdLessonAssessment { get; set; }
    public LessonAssessments? LessonAssessment { get; set; }
    
    [ForeignKey("ModuleAssessment")]
    public int? IdModuleAssessment { get; set; }
    public ModuleAssessments? ModuleAssessment { get; set; }
    
    [ForeignKey("RoadmapAssessment")]
    public int? IdRoadmapAssessment { get; set; }
    public RoadmapAssessments? RoadmapAssessment { get; set; }
}