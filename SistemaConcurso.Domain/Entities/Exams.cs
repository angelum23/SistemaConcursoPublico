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
    /// Gets or sets the unique identifier of the user taking the exam.
    /// </summary>
    /// <value>
    /// The ID that uniquely identifies the user in the system.
    /// This is a required field and must reference an existing user.
    /// </value>
    public int IdUser { get; set; }
}