using Flunt.Notifications;
using Flunt.Validations;
using JpvTech.Domain.Commands.Contracts;
using System;

namespace JpvTech.Domain.Commands
{
    public class CadastroPessoaCommand:Notifiable, ICommand
    {
        public CadastroPessoaCommand()
        {

        }

        public CadastroPessoaCommand(string nome, DateTime nascimento, double renda, string cpf)
        {
            Nome = nome;
            Nascimento = nascimento;
            Renda = renda;
            Cpf = cpf;
        }

        public string Nome { get;  set; }

        public DateTime Nascimento { get;  set; }

        public double Renda { get;  set; }

        public string Cpf { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Por favor, digite o nome completo!")
                .HasMinLen(Cpf, 11, "Cpf", "Por favor, digite corretamente seu CPF"));
        }
    }
}

