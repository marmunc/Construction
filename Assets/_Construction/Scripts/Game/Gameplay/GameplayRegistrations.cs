using _Construction.cmd;
using BaCon;

namespace _Construction.Scripts.Game
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;

            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);

            container.RegisterFactory(_ => new BuildingsService(gameState.Buildings, cmd)).AsSingle();
        }
    }
}
