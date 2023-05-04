namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
{
    public class ScoreCounter : IScoreCounter
    {
        public int CurrentScore => _currentScore;

        private int _currentScore;


        public void AddScore(int score) =>
            _currentScore += score;
    }
}
