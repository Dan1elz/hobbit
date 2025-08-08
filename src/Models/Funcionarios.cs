using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Hobbit.src.Dtos.FuncionariosDto;

namespace Hobbit.src.Models;

[Table("Funcionarios")]
public class Funcionarios
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required(ErrorMessage = "O Nif é obrigatório."), StringLength(8, ErrorMessage = "O Nif deve ter no máximo 8 caracteres.")]
    public string Nif { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O nome é obrigatório."), StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; private set; } = string.Empty;

    [Required(ErrorMessage = "O cargo é obrigatório."), StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
    public string Departamento { get; private set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória."), StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres.")]
    public string Senha { get; private set; } = string.Empty;
    
    public Funcionarios() { }
    public Funcionarios(CreateFuncionarioDto dto)
    {
        Nif = dto.Nif;
        Nome = dto.Nome;
        Departamento = dto.Departamento;
        Senha = dto.Senha;
    }
    public void Update(UpdateFuncionarioDto dto)
    {
        Nif = dto.Nif;
        Nome = dto.Nome;
        Departamento = dto.Departamento;
    }
    public void UpdateSenha(UpdateSenhaFuncionarioDto dto)
    {
        Senha = dto.Senha;
    }
}