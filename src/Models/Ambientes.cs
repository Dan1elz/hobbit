using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hobbit.src.Dtos.AmbientesDto;

namespace Hobbit.src.Models;
[Table("Ambientes")]
public class Ambientes
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O código é obrigatório."), StringLength(32, ErrorMessage = "O código deve ter no máximo 32 caracteres.")]
    public string Codigo { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; private set; } = string.Empty;

    [Required(ErrorMessage = "A localização é obrigatória.")]
    public string Localizacao { get; private set; } = string.Empty;
    public virtual ICollection<Armarios>? Armarios { get; set; } = [];

    private Ambientes() { }

    public Ambientes(CreateAmbienteDto dto)
    {
        Codigo = dto.Codigo;
        Nome = dto.Nome;
        Localizacao = dto.Localizacao;
    }
    public void Update(UpdateAmbienteDto dto)
    {
        Codigo = dto.Codigo;
        Nome = dto.Nome;
        Localizacao = dto.Localizacao;
    }
}


