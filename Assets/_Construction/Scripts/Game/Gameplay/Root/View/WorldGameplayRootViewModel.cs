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
