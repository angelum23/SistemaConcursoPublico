using System.ComponentModel;

namespace SistemaConcurso.Domain.Enums;

public enum AssessmentStatus
{
    [Description("Not started")]
    Todo = 1,
    [Description("In progress")]
    Started = 2,
    [Description("Awaiting approval")]
    Completed = 3,
    [Description("Approved")]
    Approved = 4,
    [Description("Rejected")]
    Rejected = 5
}