using System.ComponentModel.DataAnnotations;
using Hobbit.src.Enums;
using Hobbit.src.Models;

namespace Hobbit.src.Dtos;
public class ArmariosDto
{
    public class CreateArmarioDto
    {
        [Required(ErrorMessage = "O ambiente é obrigatório.")]
        public Guid AmbienteId { get; private set; }

        [Required(ErrorMessage = "O NI é obrigatório."), StringLength(50, ErrorMessage = "O NI deve ter no máximo 50 caracteres.")]
        public string Ni { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de armário é obrigatório."), EnumDataType(typeof(TipoArmarioEnum), ErrorMessage = "Tipo de armário inválido.")]
        public TipoArmarioEnum TipoArmario { get; private set; }

        public CreateArmarioDto() { }
        public CreateArmarioDto(Armarios model)
        {
            AmbienteId = model.AmbienteId;
            Ni = model.Ni;
            TipoArmario = model.TipoArmario;
        }
    }

    public class UpdateArmarioDto : CreateArmarioDto
    {
        public UpdateArmarioDto() { }
        public UpdateArmarioDto(Armarios model) : base(model) { }
    }

    public class ResponseArmarioDto : CreateArmarioDto
    {
        public Guid Id { get; private set; }

        public ResponseArmarioDto() { }
        public ResponseArmarioDto(Armarios model) : base(model)
        {
            Id = model.Id;
        }
    }
}
