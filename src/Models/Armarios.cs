using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hobbit.src.Enums;
using static Hobbit.src.Dtos.ArmariosDto;

namespace Hobbit.src.Models;
[Table("Armarios")]
public class Armarios
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [ForeignKey("Ambientes"), Required(ErrorMessage = "O ambiente é obrigatório.")]
    public Guid AmbienteId { get; private set; }
    public virtual Ambientes? Ambiente { get; set; }

    [Required(ErrorMessage = "O NI é obrigatório."), StringLength(50, ErrorMessage = "O NI deve ter no máximo 50 caracteres.")]
    public string Ni { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O tipo de armário é obrigatório."), EnumDataType(typeof(TipoArmarioEnum), ErrorMessage = "Tipo de armário inválido.")]
    public TipoArmarioEnum TipoArmario { get; private set; }
    public virtual ICollection<Itens>? Itens { get; set; } = [];

    public Armarios() { }

    public Armarios(CreateArmarioDto dto)
    {
        AmbienteId = dto.AmbienteId;
        Ni = dto.Ni;
        TipoArmario = dto.TipoArmario;
    }
    public void Update(UpdateArmarioDto dto)
    {
        AmbienteId = dto.AmbienteId;
        Ni = dto.Ni;
        TipoArmario = dto.TipoArmario;
    }

}