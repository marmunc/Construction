using _Construction.Scripts.Game;

namespace Gameplay.View
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingsService _buildingsService;

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            _buildingEntity = buildingEntity;
            _buildingsService = buildingsService;
        }
    }
}
