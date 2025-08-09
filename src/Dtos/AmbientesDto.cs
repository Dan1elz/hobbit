using System.ComponentModel.DataAnnotations;
using Hobbit.src.Models;

namespace Hobbit.src.Dtos;
public class AmbientesDto
{
    public class CreateAmbienteDto
    {
        //Adoleta 2
        [Required(ErrorMessage = "O código é obrigatório."), StringLength(32, ErrorMessage = "O código deve ter no máximo 32 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; } = string.Empty;
        public CreateAmbienteDto() { }
        public CreateAmbienteDto(Ambientes model)
        {
            Codigo = model.Codigo;
            Nome = model.Nome;
            Localizacao = model.Localizacao;
        }
    }

    public class UpdateAmbienteDto : CreateAmbienteDto
    {
        public UpdateAmbienteDto() { }
        public UpdateAmbienteDto(Ambientes model) : base(model) { }
    }

    public class ResponseAmbienteDto : CreateAmbienteDto
    {
        public Guid Id { get; set; }
        public ResponseAmbienteDto() { }
        public ResponseAmbienteDto(Ambientes model) : base(model)
        {
            Id = model.Id;
        }
    }
}