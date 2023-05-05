namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
{
    public interface IScoreCounter
    {
        public int CurrentScore { get; }
        public void AddScore(int score);
        public void Reset();
    }
}
