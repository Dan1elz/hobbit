using Hobbit.src.Services;
using Microsoft.AspNetCore.Mvc;
using static Hobbit.src.Dtos.AmbientesDto;

namespace Hobbit.src.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AmbienteController(AmbientesService service) : ControllerBase
{
    private readonly AmbientesService _service = service;

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAmbienteDto dto, CancellationToken ct)
    {
        try
        {
            var result = await _service.AddAsync(dto, ct);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao adicionar ambiente.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateAmbienteDto dto, CancellationToken ct)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto, ct);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao atualizar ambiente.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id, CancellationToken ct)
    {
        try
        {
            await _service.RemoveAsync(id, ct);
            return Ok("Ambiente excluído com sucesso.");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao excluir ambiente.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindByIdAsync([FromRoute] Guid id, CancellationToken ct)
    {
        try
        {
            var result = await _service.FindByIdAsync(id, ct);
            if (result == null)
                return NotFound("Ambiente não encontrado.");
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar ambiente.");
        }
    }

    [HttpGet("Codigo/{codigo}")]
    public async Task<IActionResult> FindByCodigoAsync([FromRoute] string codigo, CancellationToken ct)
    {
        try
        {
            var result = await _service.FindAsync(x=> x.Codigo == codigo, ct);
            if (result == null)
                return NotFound("Ambiente não encontrado.");
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar ambiente por código.");
        }
    }

    [HttpGet("Nome/{Nome}")]
    public async Task<IActionResult> FindByNomeAsync([FromRoute] string Nome, CancellationToken ct)
    {
        try
        {
            var result = await _service.FindAsync(x=> x.Nome == Nome, ct);
            if (result == null)
                return NotFound("Ambiente não encontrado.");
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar ambiente por código.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> FindAllAsync(CancellationToken ct)
    {
        try
        {
            var result = await _service.FindAllAsync(c => true, ct);
            if (result == null || result.Count == 0)
                return NotFound("Nenhum ambiente encontrado.");
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar ambientes.");
        }
    }
}