using _Construction.Scripts.Game;

namespace _Construction.Game.Gameplay.Root
{
    public class GameplayEnterParams : SceneEnterParams
    {
        public int MapId { get; }

        public GameplayEnterParams(int mapId) : base(SceneNames.GAMEPLAY)
        {
            MapId = mapId;
        }
    }
}
