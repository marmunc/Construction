using _Construction.Game.Gameplay.Services;
using _Construction.Game.Gameplay.View.Buildings;
using _Construction.Scripts.Game;
using ObservableCollections;

namespace Gameplay.View
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingsService buildingsService)
        {
            AllBuildings = buildingsService.AllBuildings;
        }
    }
}
