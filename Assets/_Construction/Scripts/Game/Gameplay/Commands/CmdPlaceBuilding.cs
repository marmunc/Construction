using _Construction.cmd;
using _Construction.Game.State.cmd;
using UnityEngine;

namespace _Construction.Game.Gameplay.Commands
{
    public class CmdPlaceBuilding : ICommand
    {
        public readonly string BuildingTypeId; // По этому айди будем находить настройки здания (ScriptableObject например)
        public readonly Vector3Int Position;

        public CmdPlaceBuilding(string buildingTypeId, Vector3Int position)
        {
            BuildingTypeId = buildingTypeId;
            Position = position;
        }
    }
}
