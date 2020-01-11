using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.Api.Models
{
    public class CategoriaGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaPost
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Limite de campo {0} é {1}")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "Limite de campo {0} é {1}")]
        public string Descricao { get; set; }
    }

    public static class CategoriaModelExtensions
    {
        public static CategoriaGet ToCategoriaGet(this Categoria categoria) =>
            new CategoriaGet
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao,
                Nome = categoria.Nome
            };


        public static Categoria ToCategoriaEntity(this CategoriaPost model) =>
            new Categoria
            {
                Nome = model.Nome,
                Descricao = model.Descricao
            };

    }
}