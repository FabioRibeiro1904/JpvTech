using JpvTech.Domain.Commands.Contracts;

namespace JpvTech.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
