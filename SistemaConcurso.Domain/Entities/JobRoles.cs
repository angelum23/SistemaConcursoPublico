using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;


/// <summary>
/// Represents a job role or position that is being offered in a public exam notice.
/// </summary>
/// <remarks>
/// This entity is used to store information about different job positions that candidates
/// can apply for within a specific public exam notice. It includes details such as the
/// role's name, description, and its association with a particular notice.
/// 
/// The class is typically populated by parsing and analyzing the content of notice files
/// to extract available job positions and their requirements.
/// </remarks>
public class JobRoles : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the job role
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets a detailed description of the job role, including requirements and responsibilities.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the foreign key reference to the associated Exam.
    /// </summary>
    public int IdExam { get; set; }
    
    public Exams Exam { get; set; }
}