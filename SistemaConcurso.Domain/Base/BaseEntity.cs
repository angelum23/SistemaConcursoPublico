using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Domain.Base;

/// <summary>
/// Provides a base class for all domain entities with common properties and behaviors.
/// </summary>
/// <remarks>
/// This abstract class implements the <see cref="IBaseEntity"/> interface and serves as the foundation
/// for all domain entities in the system. It includes common properties like Id, tracking fields,
/// and soft delete functionality.
/// 
/// Key Features:
/// - Unique identifier (Id) for each entity
/// - Soft delete mechanism with Remove() and Recover() methods
/// - Automatic tracking of creation and modification dates
/// - Thread-safe removal and recovery operations with appropriate validation
/// </remarks>
public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public bool Removed { get; private set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public void Remove()
    {
        if (Removed)
        {
            throw new Exception("Register already removed!");
        }
        
        Removed = true;
    }

    public void Recover()
    {
        if (!Removed)
        {
            throw new Exception("Register not removed!");
        }

        Removed = false;
    }
}