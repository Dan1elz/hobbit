using System.ComponentModel.DataAnnotations;
using Hobbit.src.Models;

namespace Hobbit.src.Dtos;
public class FuncionariosDto
{
    public class CreateFuncionarioDto
    {
        [Required(ErrorMessage = "O Nif é obrigatório."), StringLength(8, ErrorMessage = "O Nif deve ter no máximo 8 caracteres.")]
        public string Nif { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O cargo é obrigatório."), StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória."), StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        public CreateFuncionarioDto() { }
        public CreateFuncionarioDto(Funcionarios model)
        {
            Nif = model.Nif;
            Nome = model.Nome;
            Departamento = model.Departamento;
        }
    }

    public class UpdateFuncionarioDto
    {
        [Required(ErrorMessage = "O Nif é obrigatório."), StringLength(8, ErrorMessage = "O Nif deve ter no máximo 8 caracteres.")]
        public string Nif { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O cargo é obrigatório."), StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
        public string Departamento { get; set; } = string.Empty;

        public UpdateFuncionarioDto() { }
        public UpdateFuncionarioDto(Funcionarios model)
        {
            Nif = model.Nif;
            Nome = model.Nome;
            Departamento = model.Departamento;
        }
    }

    public class UpdateSenhaFuncionarioDto
    {
        [Required(ErrorMessage = "A senha é obrigatória."), StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        public UpdateSenhaFuncionarioDto() { }
        public UpdateSenhaFuncionarioDto(Funcionarios model)
        {
            Senha = model.Senha;
        }
    }

    public class ResponseFuncionarioDto : UpdateFuncionarioDto
    {
        public ResponseFuncionarioDto() { }
        public ResponseFuncionarioDto(Funcionarios model) : base(model) { }
    }
}
