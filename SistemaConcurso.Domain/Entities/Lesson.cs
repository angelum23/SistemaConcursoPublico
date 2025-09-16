using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents an individual learning unit within a study module for public tender preparation.
/// </summary>
/// <remarks>
/// This entity defines a specific lesson that covers particular topics or skills
/// required for the public tender. Lessons are organized within modules to provide
/// structured learning paths for candidates.
/// </remarks>
public class Lesson : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the parent module.
    /// </summary>
    /// <value>
    /// The ID that links this lesson to a specific study module.
    /// This is a required field and must reference an existing module.
    /// </value>
    public int IdModule { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the lesson.
    /// </summary>
    /// <value>
    /// A concise, descriptive title that clearly indicates the lesson's topic
    /// or learning objective (e.g., "Basic Arithmetic Operations" or "Constitutional Law Fundamentals").
    /// </value>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets a detailed description of the lesson's content.
    /// </summary>
    /// <value>
    /// A comprehensive overview of the topics covered, learning objectives,
    /// and any specific knowledge or skills that will be developed.
    /// May include references to study materials or additional resources.
    /// </value>
    public string Description { get; set; }
}