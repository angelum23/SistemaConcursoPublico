using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents an assessment for a specific module in a public tender study roadmap.
/// </summary>
/// <remarks>
/// This entity tracks the progress and evaluation of a candidate's performance
/// in a specific study module. It manages the assessment lifecycle from start
/// to completion, including approval/rejection by an evaluator.
/// </remarks>
public class Assessments : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the associated module.
    /// </summary>
    /// <value>
    /// The ID that links this assessment to a specific study module.
    /// This is a required field and must reference an existing module.
    /// </value>
    public int IdModule { get; set; }
    
    /// <summary>
    /// Gets or sets the numerical score achieved in the assessment.
    /// </summary>
    /// <value>
    /// A decimal value representing the candidate's score, typically on a scale
    /// from 0 to 10 or 0 to 100, depending on the grading system used.
    /// </value>
    public decimal Note { get; set; }
    
    /// <summary>
    /// Gets the date and time when the assessment was started.
    /// </summary>
    /// <value>
    /// The timestamp when the assessment was initiated, or null if not yet started.
    /// Automatically set when the Start() method is called.
    /// </value>
    public DateTime? StartDate { get; private set; }
    
    /// <summary>
    /// Gets the date and time when the assessment was completed.
    /// </summary>
    /// <value>
    /// The timestamp when the assessment was marked as completed, or null if not yet completed.
    /// Automatically set when the Complete() method is called.
    /// </value>
    public DateTime? EndDate { get; private set; }
    
    /// <summary>
    /// Gets the date and time when the assessment was reviewed.
    /// </summary>
    /// <value>
    /// The timestamp when the assessment was approved or rejected, or null if not yet reviewed.
    /// Automatically set when either the Approve() or Reject() method is called.
    /// </value>
    public DateTime? ReviewDate { get; private set; }
    
    /// <summary>
    /// Gets the current status of the assessment.
    /// </summary>
    /// <value>
    /// The current state of the assessment in its lifecycle (e.g., Not Started, In Progress, Completed, etc.).
    /// This value is managed internally by the class methods.
    /// </value>
    public EAssessmentStatus Status { get; private set; }

    /// <summary>
    /// Marks the assessment as approved by an evaluator.
    /// </summary>
    /// <remarks>
    /// This method updates the status to <see cref="EAssessmentStatus.Approved"/>
    /// and sets the review date to the current date and time.
    /// </remarks>
    public void Approve()
    {
        Status = EAssessmentStatus.Approved;
        ReviewDate = DateTime.Now;
    }

    
    /// <summary>
    /// Marks the assessment as rejected by an evaluator.
    /// </summary>
    /// <remarks>
    /// This method updates the status to <see cref="EAssessmentStatus.Rejected"/>
    /// and sets the review date to the current date and time.
    /// </remarks>
    public void Reject()
    {
        Status = EAssessmentStatus.Rejected;
        ReviewDate = DateTime.Now;
    }

    
    /// <summary>
    /// Marks the assessment as completed by the candidate.
    /// </summary>
    /// <remarks>
    /// This method updates the status to <see cref="EAssessmentStatus.Completed"/>
    /// and sets the end date to the current date and time.
    /// </remarks>
    public void Complete()
    {
        Status = EAssessmentStatus.Completed;
        EndDate = DateTime.Now;
    }
    
    
    /// <summary>
    /// Initiates the assessment for a candidate.
    /// </summary>
    /// <remarks>
    /// This method sets the start date to the current date and time
    /// and updates the status to <see cref="EAssessmentStatus.Started"/>.
    /// </remarks>
    public void Start()
    {
        StartDate = DateTime.Now;
        Status = EAssessmentStatus.Started;
    }
}