using SistemaConcurso.Application.Base;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Exam;
using SistemaConcurso.Domain.Interfaces.Roadmap;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Application.Applications;

public class RoadmapApplication(IRoadmapService service, IExamService examService, IUnitOfWork uow, IClaimService claimService) 
    : BaseApplication<Roadmaps>(service, uow), IRoadmapApplication
{
    public async Task<List<HomeView>> Home(IPagination pagination)
    {
        var user = claimService.GetLoggedUser();
        var exams = await examService.GetHomeData(pagination, user.Id);
        return await service.GetHomeData(exams);
    }
}