using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;

namespace SistemaConcurso.Api.Base;

public class BaseController<T>(IBaseApplication<T> aplic) : BasierController where T : IBaseEntity
{
    [HttpGet("{id:int}")]
    public Task<IActionResult> FindAsync(int id) => Controller(aplic.FindAsync(id));
    [HttpPost("Save")]
    public Task<IActionResult> SaveAsync([FromBody] T entity) => Controller(aplic.SaveAsync(entity));
    
    [HttpGet]
    public IActionResult Get([FromQuery] IPagination pagination)
    {
        try
        {
            var result = aplic.Get(pagination);
            return Ok(new
            {
                Message = "Operation completed successfully!",
                Content = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        try
        {
            await aplic.RemoveAsync(id);
            return Ok($"Register with id {id} removed successfully!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [NonAction]
    private async Task<IActionResult> Controller(Task<T> action, string okMessage = "Operation completed successfully!")
    {
        try
        {
            var result = await action;
            return Ok(new
            {
                Message = okMessage,
                Content = result
            });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}