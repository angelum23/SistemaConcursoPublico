using SistemaConcurso.Domain.Base.Extensions;
using SistemaConcurso.Domain.Enums;

namespace SistemaConcurso.Domain.Exceptions;

public class RuleException : Exception
{
    public EException Code { get; set; }
    
    public RuleException()
    {
    }

    public RuleException(string? message) : base(message)
    {
    }

    public RuleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public RuleException(EException code) : base(code.GetDescription())
    {
    }
}