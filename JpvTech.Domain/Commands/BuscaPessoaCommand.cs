using Flunt.Notifications;
using Flunt.Validations;
using JpvTech.Domain.Commands.Contracts;

namespace JpvTech.Domain.Commands
{
    public class BuscaPessoaCommand : Notifiable, ICommand
    {
        public BuscaPessoaCommand()
        {

        }
        public string Cpf { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Cpf, 9, "Cpf", "Verifique se digitou corretamente o Cpf"));
        }
    }
}
