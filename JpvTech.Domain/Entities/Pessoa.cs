using System;

namespace JpvTech.Domain.Entities
{
    public class Pessoa:Entity
    {
        public Pessoa(string nome, DateTime nascimento, double renda, string cpf)
        {
            Nome = nome;
            Nascimento = nascimento;
            Renda = renda;
            Cpf = cpf;
        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public DateTime Nascimento { get; private set; }

        public double Renda { get; private set; }

        public string Cpf { get; private set; }

        public void UpdatePessoa(string nome, double renda)
        {
            Nome = nome;
            Renda = renda;
        }
    }
}
