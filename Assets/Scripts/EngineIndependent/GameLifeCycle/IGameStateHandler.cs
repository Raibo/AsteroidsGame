namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle
{
    public interface IGameStateHandler
    {
        public bool IsPaused { get; }
        public GameState GameState { get; set; }
        public void Pause();
        public void Unpause();
    }
}
