using Flunt.Notifications;
using Flunt.Validations;
using JpvTech.Domain.Commands.Contracts;
using System;

namespace JpvTech.Domain.Commands
{
    public  class UpdatePessoaCommand: Notifiable, ICommand
    {
        public UpdatePessoaCommand()
        {

        }

        public UpdatePessoaCommand(Guid id, string nome, double renda)
        {

            Nome = nome;
            Renda = renda;
            Id = id;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public double Renda { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Por favor, digite o nome completo!"));
        }
    }
}
