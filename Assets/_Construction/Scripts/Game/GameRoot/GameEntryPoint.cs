using System.Collections;
using _Construction.Game.Gameplay.Root;
using _Construction.Game.MainMenu.Root;
using _Construction.Game.Settings;
using _Construction.Game.State;
using _Construction.Scripts.Game;
using _Construction.Utils;
using BaCon;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Construction.Game.GameRoot
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;
        private readonly DIContainer _rootContainer = new(); // Сюда можем положить состояния, сервисы аналитики, настройки (базовые штуки, которые используются во всем проекте)
        private DIContainer _cachedSceneContainer;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            Application.targetFrameRate = 60; // Установка целевого FPS
            Screen.sleepTimeout = SleepTimeout.NeverSleep; // Чтобы экран не гас(на мобилке)

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);

            // Настройки приложения
            var settingsProvider = new SettingsProvider();
            _rootContainer.RegisterInstance<ISettingsProvider>(settingsProvider);
            
            var gameStateProvider = new PlayerPrefsGameStateProvider();
            gameStateProvider.LoadSettingsState();
            _rootContainer.RegisterInstance<IGameStateProvider>(gameStateProvider);
            _rootContainer.RegisterInstance(_uiRoot);

            _rootContainer.RegisterFactory(_ => new SomeCommonService()).AsSingle();
        }


        private async void RunGame()
        {
            await _rootContainer.Resolve<ISettingsProvider>().LoadGameSettings();
            
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == SceneNames.GAMEPLAY)
            {
                var enterParams = new GameplayEnterParams(1);
                _coroutines.StartCoroutine(LoadAndStartGameplay(enterParams));
                return;
            }

            if (sceneName == SceneNames.MAIN_MENU)
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                return;
            }

            if (sceneName != SceneNames.BOOT)
            {
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams)
        {
            _uiRoot.ShowLoadingScreen();
            _cachedSceneContainer?.Dispose();

            yield return LoadScene(SceneNames.BOOT);

            var isGameStateLoaded = false;
            _rootContainer.Resolve<IGameStateProvider>().LoadGameState().Subscribe(_ => isGameStateLoaded = true);
            yield return new WaitUntil(() => isGameStateLoaded);

            yield return LoadScene(SceneNames.GAMEPLAY);

            yield return new WaitForSeconds(1f);


            var gameplayContainer = _cachedSceneContainer = new DIContainer(_rootContainer);
            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(gameplayContainer, enterParams).Subscribe(gameplayExitParams =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
            });

            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null)
        {
            _uiRoot.ShowLoadingScreen();
            _cachedSceneContainer?.Dispose();

            yield return LoadScene(SceneNames.BOOT);
            yield return LoadScene(SceneNames.MAIN_MENU);

            yield return new WaitForSeconds(1f);

            var mainMenuContainer = _cachedSceneContainer = new DIContainer(_rootContainer);
            var sceneEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(mainMenuContainer, enterParams).Subscribe(mainMenuExitParams =>
            {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;

                if (targetSceneName == SceneNames.GAMEPLAY)
                {
                    _coroutines.StartCoroutine(LoadAndStartGameplay(mainMenuExitParams.TargetSceneEnterParams.As<GameplayEnterParams>()));
                }
                
                // Дальше вписывать сцены

            });

            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
