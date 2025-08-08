using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hobbit.src.Enums;
using static Hobbit.src.Dtos.ItensDto;

namespace Hobbit.src.Models;
public class Itens
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [ForeignKey("Armarios"), Required(ErrorMessage = "O armário é obrigatório.")]
    public Guid ArmarioId { get; private set; }
    public virtual Armarios? Armario { get; set; }

    [Required(ErrorMessage = "O NI é obrigatório."), StringLength(8, ErrorMessage = "O NI deve ter no máximo 8 caracteres.")]
    public string Ni { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O tipo de item é obrigatório."), EnumDataType(typeof(TipoItemEnum), ErrorMessage = "Tipo de item inválido.")]
    public TipoItemEnum TipoItem { get; private set; }

    public Itens() { }
    public Itens(CreateItemDto dto)
    {
        ArmarioId = dto.ArmarioId;
        Ni = dto.Ni;
        Nome = dto.Nome;
        Descricao = dto.Descricao;
        TipoItem = dto.TipoItem;
    }
    public void Update(UpdateItemDto dto)
    {
        Ni = dto.Ni;
        Nome = dto.Nome;
        Descricao = dto.Descricao;
        TipoItem = dto.TipoItem;
    }
}
