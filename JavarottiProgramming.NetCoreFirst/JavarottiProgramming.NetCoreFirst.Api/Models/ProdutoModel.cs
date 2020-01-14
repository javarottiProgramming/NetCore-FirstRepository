using JavarottiProgramming.NetCoreFirst.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JavarottiProgramming.NetCoreFirst.Api.Models
{
    public class ProdutoGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }

    public class ProdutoPost
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Valor inválido para campo {0}")]
        public decimal Preco { get; set; }


        public int CategoriaId { get; set; }
    }

    public static class ProdutoModelExtensions
    {
        public static ProdutoGet ToProdutoGet(this Produto entity)
        {
            return new ProdutoGet
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                CategoriaId = entity.CategoriaId,
                CategoriaNome = entity.Categoria?.Nome
            };
        }

        public static Produto ToProdutoEntity(this ProdutoPost model)
        {
            return new Produto
            {
                Nome = model.Nome,
                Preco = model.Preco,
                CategoriaId = model.CategoriaId
            };
        }
    }
}