using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hobbit.src.Enums;
using static Hobbit.src.Dtos.MovimentacoesDto;

namespace Hobbit.src.Models
{
    public class Movimentacoes
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [ForeignKey("Itens"), Required(ErrorMessage = "O item é obrigatório.")]
        public Guid ItemId { get; private set; }
        public virtual Itens? Item { get; set; }

        [ForeignKey("Funcionarios"), Required(ErrorMessage = "O funcionário é obrigatório.")]
        public Guid FuncionarioId { get; private set; }
        public virtual Funcionarios? Funcionario { get; set; }

        [Required(ErrorMessage = "A data da movimentação é obrigatória.")]
        public DateTime DataMovimentacao { get; private set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "O tipo de movimentação é obrigatório."), EnumDataType(typeof(TipoMovimentacao), ErrorMessage = "Tipo de movimentação inválido.")]
        public TipoMovimentacao TipoMovimentacao { get; private set; }

        public Movimentacoes() { }
        public Movimentacoes(CreateMovimentacaoDto dto)
        {
            ItemId = dto.ItemId;
            FuncionarioId = dto.FuncionarioId;
            TipoMovimentacao = dto.TipoMovimentacao;
        } 
    }
}