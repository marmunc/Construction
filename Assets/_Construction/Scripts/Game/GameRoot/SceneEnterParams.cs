namespace _Construction.Scripts.Game
{
    public abstract class SceneEnterParams
    {
        public string SceneName { get; }

        public SceneEnterParams(string sceneName)
        {
            SceneName = sceneName;
        }

        //Converter
        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}
