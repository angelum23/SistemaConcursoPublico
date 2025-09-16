using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a public exam notice in the system.
/// </summary>
/// <remarks>
/// This class contains information about public examination notices, including their title,
/// description, and associated files. It serves as the main entity for managing and
/// displaying examination notices to candidates.
/// </remarks>
public class Notices : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of the public exam notice.
    /// </summary>
    /// <value>The title should be a concise description of the notice (e.g., "Public Tender 2024 - City Hall").</value>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets the detailed description of the public exam notice.
    /// </summary>
    /// <value>Contains comprehensive information about the exam, including requirements, dates, and other relevant details.</value>
    public string Description { get; set; }
    
    /// <summary>
    /// Gets or sets the file path or reference to the official notice document.
    /// </summary>
    /// <value>This will be the full text of the notice.</value>
    public string File { get; set; }
}