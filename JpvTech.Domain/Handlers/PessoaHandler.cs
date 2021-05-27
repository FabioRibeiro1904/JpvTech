using JpvTech.Domain.Commands;
using JpvTech.Domain.Commands.Contracts;
using JpvTech.Domain.Entities;
using JpvTech.Domain.Handlers.Contracts;
using JpvTech.Domain.Repository;

namespace JpvTech.Domain.Handlers
{
    public class PessoaHandler : IHandler<CadastroPessoaCommand>, IHandler<BuscaPessoaCommand>, IHandler<UpdatePessoaCommand>

    {
        private readonly IPessoaRepository _repository;
        public PessoaHandler(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastroPessoaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Verifique por gentileza os campos preenchidos", 
                    command.Notifications);

            var cpf = command.Cpf.Trim().Replace(".", "").Replace("-", "");

            var pessoa = new Pessoa(command.Nome, command.Nascimento, command.Renda, cpf);

            _repository.Create(pessoa);

            return new GenericCommandResult(true, "Pessoa fisíca criada com sucesso", pessoa);
        }

        public ICommandResult Handle(BuscaPessoaCommand command)
        {
            command.Validate();
                if (command.Invalid)
                return new GenericCommandResult(false, "Verifique o cpf digitado", command.Notifications);

            var cpfValid = _repository.GetCpf(command.Cpf);
            return new GenericCommandResult(true, "Cliente encontrado", cpfValid);
        }

        public ICommandResult Handle(UpdatePessoaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Verifique por gentileza os campos preenchidos", command.Notifications);

            var pessoa = _repository.GetById(command.Id) ;

            pessoa.UpdatePessoa(command.Nome, command.Renda);

            _repository.Update(pessoa);

            return new GenericCommandResult(true, "Pessoa atualizada com sucesso", pessoa);
        }

    }
}
