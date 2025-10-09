using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Module;

namespace SistemaConcurso.Api.Controllers;

public class ModuleController(IModuleApplication aplic) : BaseController<Modules>(aplic)
{
    [HttpGet("List/{roadmapId:int}")]
    public async Task<IActionResult> List([FromHeader] IPagination pagination, int roadmapId) =>
        await Controller(aplic.List(pagination, roadmapId));
}