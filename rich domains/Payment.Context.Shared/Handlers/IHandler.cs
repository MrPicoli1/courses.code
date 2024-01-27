using Payment.Context.Shared.Commands;

namespace Payment.Context.Shared.Handlers
{
     public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
