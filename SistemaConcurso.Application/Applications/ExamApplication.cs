using SistemaConcurso.Application.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces;
using SistemaConcurso.Domain.Interfaces.Exam;

namespace SistemaConcurso.Application.Applications;

public class ExamApplication(IExamService service, IUnitOfWork uow) : BaseApplication<Exams>(service, uow), IExamApplication
{
    
}