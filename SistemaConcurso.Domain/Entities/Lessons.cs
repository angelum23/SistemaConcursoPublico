using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents an individual learning unit within a study module for public tender preparation.
/// </summary>
/// <remarks>
/// This entity defines a specific lesson that covers particular topics or skills
/// required for the public tender. Lessons are organized within modules to provide
/// structured learning paths for candidates.
/// </remarks>
public class Lessons : BaseEntity
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
    /// <summary>
    /// Gets or sets a value indicating whether the lesson has been marked as completed.
    /// </summary>
    /// <value>
    /// <c>true</c> if the lesson is marked as done; otherwise, <c>false</c>.
    /// This property has a private setter and should be modified using the
    /// <see cref="MarkDone"/> and <see cref="MarkTodo"/> methods.
    /// </value>
    public bool Done { get; private set; }

    /// <summary>
    /// Marks the current lesson as completed.
    /// </summary>
    /// <exception cref="RuleException">
    /// Thrown when the lesson is already marked as done.
    /// The exception type is <see cref="EException.LessonAlreadyDone"/>.
    /// </exception>
    public void MarkDone()
    {
        if (Done) throw new RuleException(EException.LessonAlreadyDone);
        Done = true;
    }

    /// <summary>
    /// Marks the current lesson as not completed (to-do).
    /// </summary>
    /// <exception cref="RuleException">
    /// Thrown when the lesson is already marked as to-do.
    /// The exception type is <see cref="EException.LessonAlreadyTodo"/>.
    /// </exception>
    public void MarkTodo()
    {
        if (!Done) throw new RuleException(EException.LessonAlreadyTodo);
        Done = false;
    }
}