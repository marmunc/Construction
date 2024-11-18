using _Construction.Scripts.Game;
using System;
using System.Collections.Generic;
using _Construction.Game.State.cmd;

namespace _Construction.cmd
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<Type, object> _handlesMap = new();
        private readonly IGameStateProvider _gameStateProvider;

        public CommandProcessor(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }

        public bool Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (_handlesMap.TryGetValue(typeof(TCommand), out var handler))
            {
                var typedHandler = (ICommandHandler<TCommand>)handler;
                var result = typedHandler.Handle(command);

                if (result)
                {
                    _gameStateProvider.SaveGameState();
                }

                return result;
            }
            return false;
        }

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlesMap[typeof(TCommand)] = handler;
        }
    }
}
