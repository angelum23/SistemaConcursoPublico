using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a study roadmap for public tender preparation.
/// </summary>
/// <remarks>
/// This entity defines the structure and content of a study plan tailored for specific
/// job roles in public tenders. It helps candidates organize their study materials
/// and track their preparation progress effectively.
/// </remarks>
public class Roadmaps : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the associated exam.
    /// </summary>
    /// <value>
    /// The ID that links this roadmap to a specific exam instance.
    /// This is a required field and must reference an existing exam.
    /// </value>
    public int IdExam { get; set; }
    /// <summary>
    /// Gets or sets the unique identifier of the job role this roadmap is designed for.
    /// </summary>
    /// <value>
    /// The ID of the specific job role (e.g., Analyst, Technician) that determines
    /// the study content and requirements for this roadmap.
    /// This is a required field and must reference a valid job role.
    /// </value>
    public int IdSelectedJobRole { get; set; }
}