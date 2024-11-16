using System.Collections.Generic;
using _Construction.Game.Gameplay.Services;
using _Construction.Game.Settings.Gameplay.Buildings;
using _Construction.Scripts.Game;
using R3;
using UnityEngine;

namespace _Construction.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingsService _buildingsService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();

        public readonly int BuildingEntityId;
        public readonly string TypeId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }

        public BuildingViewModel(
            BuildingEntityProxy buildingEntity,
            BuildingSettings buildingSettings,
            BuildingsService buildingsService)
        {
            BuildingEntityId = buildingEntity.Id;
            TypeId = buildingEntity.TypeId;

            _buildingEntity = buildingEntity;
            _buildingSettings = buildingSettings;
            _buildingsService = buildingsService;

            foreach (var buildingLevelSettings in buildingSettings.LevelsSettings)
            {
                _levelSettingsMap[buildingLevelSettings.level] = buildingLevelSettings;
            }
            
            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}
