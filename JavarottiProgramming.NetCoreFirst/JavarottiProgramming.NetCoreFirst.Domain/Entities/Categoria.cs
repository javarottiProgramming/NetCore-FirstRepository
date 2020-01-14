using System;
using System.Collections.Generic;

namespace JavarottiProgramming.NetCoreFirst.Domain.Entities
{
    public class Categoria : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public void Update(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}