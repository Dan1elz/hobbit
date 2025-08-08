using System.ComponentModel.DataAnnotations;
using Hobbit.src.Enums;
using Hobbit.src.Models;

namespace Hobbit.src.Dtos;
public class ItensDto
{
    public class CreateItemDto
    {
        [Required(ErrorMessage = "O armário é obrigatório.")]
        public Guid ArmarioId { get; private set; }

        [Required(ErrorMessage = "O NI é obrigatório."), StringLength(8, ErrorMessage = "O NI deve ter no máximo 8 caracteres.")]
        public string Ni { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; private set; } = string.Empty;
        public string? Descricao { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de item é obrigatório."), EnumDataType(typeof(TipoItemEnum), ErrorMessage = "Tipo de item inválido.")]
        public TipoItemEnum TipoItem { get; private set; }

        public CreateItemDto() { }
        public CreateItemDto(Itens model)
        {
            ArmarioId = model.ArmarioId;
            Ni = model.Ni;
            Nome = model.Nome;
            Descricao = model.Descricao;
            TipoItem = model.TipoItem;
        }
    }

    public class UpdateItemDto : CreateItemDto
    {
        public UpdateItemDto() { }
        public UpdateItemDto(Itens model) : base(model) { }
    }

    public class ResponseItemDto : CreateItemDto
    {
        public Guid Id { get; private set; }
        public ResponseItemDto() { }
        public ResponseItemDto(Itens model) : base(model)
        {
            Id = model.Id;
        }
    }
}
