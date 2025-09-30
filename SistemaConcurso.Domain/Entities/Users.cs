using SistemaConcurso.Domain.Base;
using System.Security.Cryptography;
using System.Text;


namespace SistemaConcurso.Domain.Entities;

/// <summary>
/// Represents a user in the system with basic identification information.
/// </summary>
/// <remarks>
/// This class serves as the main entity for user management, storing essential
/// user information and authentication details. It inherits from <see cref="BaseEntity"/>
/// to provide common properties like Id and audit fields.
/// This class handles secure storage and retrieval of user passwords using AES encryption.
/// Note: For production use, consider using a more secure approach for key management
/// rather than hardcoding encryption keys in the source code.
/// </remarks>
public class Users : BaseEntity
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    /// <value>The complete name including first name and last name.</value>
    public string? FullName { get; set; }
    
    /// <summary>
    /// Gets or sets the user's username.
    /// </summary>
    /// <value>The username used for user identification and communication.</value>
    public required string Username { get; set; }
    
    /// <summary>
    /// Gets or sets the user's email address.
    /// </summary>
    /// <value>The email address used for user identification and communication.</value>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the encrypted password.
    /// </summary>
    /// <value>The password in its encrypted form. This should never be stored in plain text.</value>
    public string Password { get; private set; } = string.Empty;
    
    public List<Exams> Exams { get; set; } = [];

    #region Rules

    /// <summary>
    /// Encryption key used for AES-256 encryption.
    /// </summary>
    /// <remarks>
    /// WARNING: In a production environment, this key should be stored in a secure
    /// configuration system or key vault, not hardcoded in source.
    /// </remarks>
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("SecretKey999SecretKey999"); // 32 bytes for AES-256

    /// <summary>
    /// Initialization vector used for AES encryption.
    /// </summary>
    private static readonly byte[] Iv  = Encoding.UTF8.GetBytes("InitVector123456"); // 16 bytes
    
    /// <summary>
    /// Encrypts and stores the provided plain text password.
    /// </summary>
    /// <param name="plainText">The password in plain text to be encrypted and stored.</param>
    /// <exception cref="ArgumentNullException">Thrown when plainText is null or empty.</exception>
    /// <remarks>
    /// This method uses AES encryption to securely store the password.
    /// The password is never stored in plain text.
    /// </remarks>
    public void SetPassword(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = Iv;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
            sw.Flush();
            cs.FlushFinalBlock();
        }

        Password = Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// Decrypts and returns the stored password.
    /// </summary>
    /// <returns>The decrypted password in plain text.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no password has been set.</exception>
    private string GetPassword()
    {
        if (string.IsNullOrEmpty(Password)) return string.Empty;

        try
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = Iv;

            var buffer = Convert.FromBase64String(Password);
            using var ms = new MemoryStream(buffer);
            using var decryptor = aes.CreateDecryptor();
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);
            return sr.ReadToEnd();
        }
        catch (Exception ex) when (ex is FormatException or CryptographicException)
        {
            throw new InvalidOperationException("Failed to decrypt password.");
        }
    }
    
    /// <summary>
    /// Checks whether the provided plain text password matches the stored encrypted password.
    /// </summary>
    /// <param name="plainText">The password to be checked in plain text.</param>
    /// <returns>True if the provided password matches the stored password, false otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when plainText is null or empty.</exception>
    /// <remarks>
    /// This method uses the <see cref="GetPassword"/> method to decrypt the stored password
    /// and compare it with the provided plain text password.
    /// </remarks>
    public bool CheckPassword(string plainText)
    {
        return GetPassword() == plainText;
    }

    #endregion
}