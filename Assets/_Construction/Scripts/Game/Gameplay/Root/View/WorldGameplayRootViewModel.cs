using System;
using _Construction.Game.Gameplay.Services;
using _Construction.Game.Gameplay.View.Buildings;
using _Construction.Game.State.GameResources;
using BaCon;
using ObservableCollections;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.View
{
    public class WorldGameplayRootViewModel
    {
        private readonly ResourcesService _resourcesService;
        
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(DIContainer container)
        {
            var buildingsService = container.Resolve<BuildingsService>();
            _resourcesService = container.Resolve<ResourcesService>();
            
            AllBuildings = buildingsService.AllBuildings;
            
            _resourcesService.ObserveResource(ResourceType.SoftCurrency)
                .Subscribe(newValue => Debug.Log($"SoftCurrency: {newValue}"));
            
            _resourcesService.ObserveResource(ResourceType.HardCurrency)
                .Subscribe(newValue => Debug.Log($"HardCurrency: {newValue}"));
            
            _resourcesService.ObserveResource(ResourceType.Wood)
                .Subscribe(newValue => Debug.Log($"Wood: {newValue}"));
        }

        public void HandleTestInput()
        {
            var rResourceType = (ResourceType)Random.Range(0, Enum.GetNames(typeof(ResourceType)).Length);
            var rValue = Random.Range(1, 1000);
            var rOperation = Random.Range(0, 2);

            if (rOperation == 0)
            {
                _resourcesService.AddResources(rResourceType, rValue);
                return;
            }

            _resourcesService.TrySpendResources(rResourceType, rValue);
        }
    }
}
