using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Domain.Base.Interfaces;

namespace SistemaConcurso.Api.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseController<T>(IBaseApplication<T> aplic) : ControllerBase where T : IBaseEntity
{
    public Task<IActionResult> FindAsync(int id) => Controller(aplic.FindAsync(id));
    public Task<IActionResult> SaveAsync(T entity) => Controller(aplic.SaveAsync(entity));
    

    public IActionResult Get()
    {
        try
        {
            var result = aplic.Get();
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