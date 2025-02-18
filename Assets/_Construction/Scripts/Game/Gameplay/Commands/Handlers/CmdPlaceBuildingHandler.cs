using System.Linq;
using _Construction.cmd;
using _Construction.Game.State.cmd;
using _Construction.Game.State.Entities.Buildings;
using _Construction.Game.State.Root;
using _Construction.Scripts.Game;
using UnityEngine;

namespace _Construction.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy _gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(CmdPlaceBuilding command)
        {
            var currentMap = _gameState.Maps.FirstOrDefault(m => m.Id == _gameState.CurrentMapId.CurrentValue);
            if (currentMap == null)
            {
                Debug.Log($"Couldn't find MatState for id: {_gameState.CurrentMapId.CurrentValue}");
                return false;
            }
                
                
            var entityId = _gameState.CreateEntityId();
            var newBuildingEntity = new BuildingEntity
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            currentMap.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}
