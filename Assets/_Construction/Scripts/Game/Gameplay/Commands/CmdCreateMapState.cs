using _Construction.Game.State.cmd;

namespace _Construction.Game.Gameplay.Commands
{
    public class CmdCreateMapState: ICommand
    {
        public readonly int MapId;

        public CmdCreateMapState(int mapId)
        {
            MapId = mapId;
        }
    }
}