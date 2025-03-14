﻿using _Construction.Game.Gameplay.Services;
using _Construction.Game.Gameplay.View.UI;
using _Construction.Scripts.Game;
using BaCon;

namespace Gameplay.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new GameplayUIManager(container)).AsSingle();
            container.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel(container)).AsSingle();
        }
    }
}
