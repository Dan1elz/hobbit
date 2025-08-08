using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hobbit.src.Models;

public class RefreshTokens
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [ForeignKey("Funcionarios"), Required(ErrorMessage = "O funcionário é obrigatório.")]
    public Guid FuncionarioId { get; private set; }
    public virtual Funcionarios? Funcionario { get; set; }

    [Required(ErrorMessage = "O token é obrigatório.")]
    public string Value { get; private set; } = string.Empty;

    public RefreshTokens() { }
    public RefreshTokens(Guid funcionarioId, string value)
    {
        FuncionarioId = funcionarioId;
        Value = value;
    }
}