namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IScoreCounter
    {
        public int CurrentScore { get; }
        public void AddScore(int score);
    }
}
