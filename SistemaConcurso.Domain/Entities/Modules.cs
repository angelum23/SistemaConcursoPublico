using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a study module within a public tender preparation roadmap.
/// </summary>
/// <remarks>
/// This entity defines a specific learning unit or section within a study roadmap,
/// typically covering a particular subject area or topic required for the tender.
/// Modules help organize study content into manageable, focused segments.
/// </remarks>
public class Modules : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of the study module.
    /// </summary>
    /// <value>
    /// A brief, descriptive title that identifies the subject or topic area
    /// covered by this module (e.g., "Mathematics", "Portuguese Language").
    /// This is a required field.
    /// </value>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets a detailed description of the module's content.
    /// </summary>
    /// <value>
    /// A comprehensive overview of the topics, concepts, and learning objectives
    /// covered in this module. This may include specific sub-topics or skills
    /// that candidates should master.
    /// </value>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the unique identifier of the parent roadmap.
    /// </summary>
    /// <value>
    /// The ID that links this module to a specific study roadmap.
    /// This is a required field and must reference an existing roadmap.
    /// </value>
    public int IdRoadmap { get; set; }
}