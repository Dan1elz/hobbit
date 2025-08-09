using System.ComponentModel.DataAnnotations;
using Hobbit.src.Enums;
using Hobbit.src.Models;

namespace Hobbit.src.Dtos;
public class MovimentacoesDto
{
    public class CreateMovimentacaoDto
    {
        [Required(ErrorMessage = "O item é obrigatório.")]
        public Guid ItemId { get; set; }

        [Required(ErrorMessage = "O funcionário é obrigatório.")]
        public Guid FuncionarioId { get; set; }

        [Required(ErrorMessage = "O tipo de movimentação é obrigatório."), EnumDataType(typeof(TipoMovimentacao), ErrorMessage = "Tipo de movimentação inválido.")]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public CreateMovimentacaoDto() { }

        public CreateMovimentacaoDto(Movimentacoes model)
        {
            ItemId = model.ItemId;
            FuncionarioId = model.FuncionarioId;
            TipoMovimentacao = model.TipoMovimentacao;
        }
    }
    

    public class ResponseMovimentacaoDto : CreateMovimentacaoDto
    {
        public Guid Id { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public ResponseMovimentacaoDto() { }

        public ResponseMovimentacaoDto(Movimentacoes model) : base(model)
        {
            Id = model.Id;
            DataMovimentacao = model.DataMovimentacao;
        }
    }
}