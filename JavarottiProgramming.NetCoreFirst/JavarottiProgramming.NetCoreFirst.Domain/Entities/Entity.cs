using System;

namespace JavarottiProgramming.NetCoreFirst.Domain.Entities
{
    //Classe abstrata não é possível instanciar, apenas usa-la como herança
    public abstract class Entity
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}