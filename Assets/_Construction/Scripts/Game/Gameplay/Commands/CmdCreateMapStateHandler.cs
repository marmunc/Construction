using System.Collections.Generic;
using System.Linq;
using _Construction.Game.Settings;
using _Construction.Game.State.cmd;
using _Construction.Game.State.Entities.Buildings;
using _Construction.Game.State.Maps;
using _Construction.Game.State.Root;
using UnityEngine;

namespace _Construction.Game.Gameplay.Commands
{
    public class CmdCreateMapStateHandler : ICommandHandler<CmdCreateMapState>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameSettings _gameSettings;
        public CmdCreateMapStateHandler(GameStateProxy gameState, GameSettings gameSettings)
        {
            _gameState = gameState;
            _gameSettings = gameSettings;
        }
        public bool Handle(CmdCreateMapState command)
        {
            var isMapAlreadyExisted = _gameState.Maps.Any(m => m.Id == command.MapId);
            
            if (isMapAlreadyExisted)
            {
                Debug.LogError($"Map with Id = {command.MapId} already exists");
                return false;
            }
            
            var newMapSettings = _gameSettings.MapsSettings.Maps.First(m => m.MapId == command.MapId);
            var newMapInitialStateSettings = newMapSettings.InitialStateSettings;
            
            var initialBuildings = new List<BuildingEntity>();
            foreach (var buildingSettings in newMapInitialStateSettings.Buildings)
            {
                var initialBuilding = new BuildingEntity
                {
                    Id = _gameState.CreateEntityId(),
                    TypeId = buildingSettings.TypeId,
                    Position = buildingSettings.Position,
                    Level = buildingSettings.Level
                };
                initialBuildings.Add(initialBuilding);
            }
            
            var newMapState = new MapState
            {
                Id = command.MapId,
                Buildings = initialBuildings
            };
            
            var newMapStateProxy = new Map(newMapState);
            _gameState.Maps.Add(newMapStateProxy);
            
            return true;
        }
    }
}