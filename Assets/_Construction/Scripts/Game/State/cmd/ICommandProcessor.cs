namespace _Construction.Game.State.cmd
{
    public interface ICommand { } // Команда

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        public bool Handle(TCommand command);
    }

    public interface ICommandProcessor
    {
        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        public bool Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
