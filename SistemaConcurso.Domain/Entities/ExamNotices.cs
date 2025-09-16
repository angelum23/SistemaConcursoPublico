using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents the relationship between an exam and its associated notice in the system.
/// </summary>
/// <remarks>
/// This entity serves as a junction table that links exams to their corresponding public notices.
/// It enables the system to track which exams are associated with which public notices.
/// </remarks>
public class ExamNotices : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the exam.
    /// </summary>
    /// <value>
    /// The ID that uniquely identifies the exam in the system.
    /// This is a required field and must reference an existing exam.
    /// </value>
    public int IdExam { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier of the associated notice.
    /// </summary>
    /// <value>
    /// The ID that uniquely identifies the public notice in the system.
    /// This is a required field and must reference an existing notice.
    /// </value>
    public int IdNotice { get; set; }
}