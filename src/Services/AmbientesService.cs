using System.Linq.Expressions;
using Hobbit.src.Interfaces;
using Hobbit.src.Models;
using static Hobbit.src.Dtos.AmbientesDto;

namespace Hobbit.src.Services;

public class AmbientesService(IAmbientesRepository repository)
{
    private readonly IAmbientesRepository _repository = repository;
    public async Task<ResponseAmbienteDto> AddAsync(CreateAmbienteDto dto, CancellationToken ct)
    {
        Ambientes ambiente = new(dto);
        await _repository.CreateAsync(ambiente, ct);
        return new ResponseAmbienteDto(ambiente);
    }
    public async Task<ResponseAmbienteDto> UpdateAsync(Guid id, UpdateAmbienteDto dto, CancellationToken ct)
    {
        var ambienteToUpdate = await _repository.GetByIdAsync(id, ct)
            ?? throw new Exception("Ambiente não encontrado.");
        ambienteToUpdate.Update(dto);
        await _repository.UpdateAsync(ambienteToUpdate, ct);
        return new ResponseAmbienteDto(ambienteToUpdate);
    }
    public async Task RemoveAsync(Guid id, CancellationToken ct)
    {
        var ambiente = await _repository.GetByIdAsync(id, ct)
            ?? throw new Exception("Ambiente não encontrado.");
        await _repository.RemoveAsync(ambiente, ct);
    }
    public async Task<ResponseAmbienteDto> FindByIdAsync(Guid id, CancellationToken ct)
    {
        var ambiente = await _repository.GetByIdAsync(id, ct)
           ?? throw new Exception("Ambiente não encontrado.");

        return new ResponseAmbienteDto(ambiente);
    }
    public async Task<ResponseAmbienteDto> FindAsync(Expression<Func<Ambientes, bool>> expression, CancellationToken ct)
    {
        var ambiente = await _repository.GetAsync(expression, ct)
            ?? throw new Exception("Ambiente não encontrado.");

        return new ResponseAmbienteDto(ambiente);
    }
    public async Task<List<ResponseAmbienteDto>?> FindAllAsync(Expression<Func<Ambientes, bool>> expression, CancellationToken ct)
    {
        var ambientes = await _repository.GetAllAsync(expression, ct);
        if (ambientes == null || ambientes.Count == 0)
            return null;

        return [.. ambientes.Select(a => new ResponseAmbienteDto(a))];
    }
}