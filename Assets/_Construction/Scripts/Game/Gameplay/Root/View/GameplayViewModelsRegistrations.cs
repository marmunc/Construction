using _Construction.Scripts.Game;
using BaCon;

namespace Gameplay.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeGameplayService>())).AsSingle();
            container.RegisterFactory(c => new WorldGameplayViewModel()).AsSingle();
        }
    }
}
