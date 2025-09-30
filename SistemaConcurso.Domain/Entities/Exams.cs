using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents an exam instance taken by a user in the system.
/// </summary>
/// <remarks>
/// This entity tracks user participation in exams and their selected job roles.
/// It serves as a record of which user is taking which exam and their chosen job role.
/// </remarks>
public class Exams : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of the public exam notice.
    /// </summary>
    /// <value>The title should be a concise description of the notice (e.g., "Public Tender 2024 - City Hall").</value>
    public string? NoticeTitle { get; set; }
    
    /// <summary>
    /// Gets or sets the detailed description of the public exam notice.
    /// </summary>
    /// <value>Contains comprehensive information about the exam, including requirements, dates, and other relevant details.</value>
    public string? NoticeDescription { get; set; }
    
    /// <summary>
    /// Gets or sets the file path or reference to the official notice document.
    /// </summary>
    /// <value>This will be the full text of the notice.</value>
    public string? Notice { get; set; }
    
    /// <summary>
    /// Gets or sets the unique identifier of the user taking the exam.
    /// </summary>
    /// <value>
    /// The ID that uniquely identifies the user in the system.
    /// This is a required field and must reference an existing user.
    /// </value>
    public int IdUser { get; set; }
    
    /// <summary>
    /// Gets or sets the user taking the exam.
    /// </summary>
    /// <value>
    /// The user who is taking the exam.
    /// This is a required field and must reference an existing user.
    /// </value>
    public Users? User { get; set; }

    public List<JobRoles> JobRoles { get; set; } = [];
    
    public Roadmaps Roadmap { get; set; }
}