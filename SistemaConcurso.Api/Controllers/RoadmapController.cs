using Microsoft.AspNetCore.Authorization;
using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Roadmap;

namespace SistemaConcurso.Api.Controllers;

[Authorize]
public class RoadmapController(IRoadmapApplication aplic) : BaseController<Roadmaps>(aplic)
{
    
}