using System.ComponentModel;

namespace SistemaConcurso.Domain.Enums;

public enum EException
{
    [Description("Email already in use!")]
    EmailAlreadyInUse = 1,
    [Description("Username already in use!")]
    UsernameAlreadyInUse = 2,
    [Description("Invalid email or password!")]
    InvalidCredentials = 3,
    [Description("Register already removed!")]
    RegisterAlreadyRemoved = 4,
    [Description("Register not removed!")]
    RegisterNotRemoved = 5,
    [Description("Register not found!")]
    RegisterNotFound = 6,
    [Description("Login failed!")]
    LoginFailed = 7,
    [Description("Register failed!")]
    RegisterFailed = 8,
    [Description("An error has occurred, try again later!")]
    GeneralError = 9,
}