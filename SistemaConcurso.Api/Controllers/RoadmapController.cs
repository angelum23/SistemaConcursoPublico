using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Roadmap;

namespace SistemaConcurso.Api.Controllers;

[Authorize]
public class RoadmapController(IRoadmapApplication aplic) : BaseController<Roadmaps>(aplic)
{
    [HttpGet("Home")]
    public async Task<IActionResult> Home() => await Controller(aplic.Home());
}