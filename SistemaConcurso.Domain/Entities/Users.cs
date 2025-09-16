using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a user in the system with basic identification information.
/// </summary>
/// <remarks>
/// This class serves as the main entity for user management, storing essential
/// user information and authentication details. It inherits from <see cref="BaseEntity"/>
/// to provide common properties like Id and audit fields.
/// </remarks>
public class Users : BaseEntity
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    /// <value>The complete name including first name and last name.</value>
    public required string FullName { get; set; }
    
    /// <summary>
    /// Gets or sets the unique username for the user account.
    /// </summary>
    /// <value>
    /// The username used for authentication and identification within the system.
    /// Must be unique across all users.
    /// </value>
    public required string Username { get; set; }
}