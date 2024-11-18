using _Construction.Game.State.Root;
using R3;

namespace _Construction.Scripts.Game
{
    public interface IGameStateProvider
    {
        public GameStateProxy GameState { get; }
        public GameSettingsStateProxy SettingsState { get; }

        public Observable<GameStateProxy> LoadGameState();
        public Observable<bool> SaveGameState();
        public Observable<bool> SaveSettingsState();
        public Observable<bool> ResetGameState();
        public Observable<GameSettingsStateProxy> ResetSettingsState();
    }
}
