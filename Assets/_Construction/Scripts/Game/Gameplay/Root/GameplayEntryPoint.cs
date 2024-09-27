﻿using _Construction.cmd;
using BaCon;
using Gameplay.View;
using ObservableCollections;
using R3;
using UnityEngine;

namespace _Construction.Scripts.Game
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            var gameplayViewModelsContainer = new DIContainer(gameplayContainer);
            GameplayViewModelsRegistrations.Register(gameplayViewModelsContainer);

            var gameStateProvider = gameplayContainer.Resolve<IGameStateProvider>();

            ///

            gameStateProvider.GameState.Buildings.ObserveAdd().Subscribe(e =>
            {
                var building = e.Value;
                Debug.Log("Building placed. Type id: " +
                          building.TypeId
                          + " Id: " + building.Id
                          + ", Position: " +
                          building.Position.Value);
            }
            );

            /// 

            var buildingsService = gameplayContainer.Resolve<BuildingsService>();
            buildingsService.PlaceBuilding("Васян", GetRandomPosition());
            buildingsService.PlaceBuilding("Стасян", GetRandomPosition());
            buildingsService.PlaceBuilding("Борян", GetRandomPosition());

            /// 

            // For test:
            gameplayViewModelsContainer.Resolve<UIGameplayRootViewModel>();
            gameplayViewModelsContainer.Resolve<WorldGameplayViewModel>();

            var uiRoot = gameplayContainer.Resolve<UIRootView>();
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSceneSignalSubj);

            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = {enterParams.SaveFileName}, level number = {enterParams.LevelNumber}");

            var mainMenuEnterParams = new MainMenuEnterParams("Fatality");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }

        private Vector3Int GetRandomPosition()
        {
            var rX = Random.Range(-10, 10);
            var rY = Random.Range(-10, 10);
            var rPosition = new Vector3Int(rX, rY, 0);

            return rPosition;
        }
    }
}