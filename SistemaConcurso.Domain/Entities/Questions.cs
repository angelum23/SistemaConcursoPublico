using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a multiple-choice question within an assessment for public tender preparation.
/// </summary>
/// <remarks>
/// This entity defines the structure of assessment questions, including the question text,
/// multiple-choice options, and tracking of correct and selected answers.
/// </remarks>
public class Questions : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the parent assessment.
    /// </summary>
    /// <value>
    /// The ID that links this question to a specific assessment.
    /// This is a required field and must reference an existing assessment.
    /// </value>
    public int IdAssessment { get; set; }
    
    /// <summary>
    /// Gets or sets the question text.
    /// </summary>
    /// <value>
    /// The actual question being asked. This should be clear, concise,
    /// and free from any formatting or markdown.
    /// </value>
    public string Question { get; set; }
    
    /// <summary>
    /// Gets or sets the text for option A.
    /// </summary>
    /// <value>
    /// The first possible answer choice for the question.
    /// </value>
    public string OptionA { get; set; }
    
    /// <summary>
    /// Gets or sets the text for option B.
    /// </summary>
    /// <value>
    /// The second possible answer choice for the question.
    /// </value>
    public string OptionB { get; set; }
    
    /// <summary>
    /// Gets or sets the text for option C.
    /// </summary>
    /// <value>
    /// The third possible answer choice for the question.
    /// </value>
    public string OptionC { get; set; }
    
    /// <summary>
    /// Gets or sets the text for option D.
    /// </summary>
    /// <value>
    /// The fourth possible answer choice for the question.
    /// </value>
    public string OptionD { get; set; }
    
    /// <summary>
    /// Gets or sets the correct answer for this question.
    /// </summary>
    /// <value>
    /// The letter (A, B, C, or D) corresponding to the correct answer.
    /// This is used for automatic grading of the assessment.
    /// </value>
    public EOptionChar CorrectEOption { get; set; }
    
    /// <summary>
    /// Gets or sets the option selected by the candidate.
    /// </summary>
    /// <value>
    /// The letter (A, B, C, or D) corresponding to the candidate's answer.
    /// This is initially null until the candidate selects an option.
    /// </value>
    public EOptionChar? SelectedOption { get; set; }
}