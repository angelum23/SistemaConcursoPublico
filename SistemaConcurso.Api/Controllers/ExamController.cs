using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Exam;

namespace SistemaConcurso.Api.Controllers;

public class ExamController(IExamApplication aplic) : BaseController<Exams>(aplic)
{
    
}