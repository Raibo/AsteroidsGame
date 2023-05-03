using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities
{
    public class ScoreCounter : IScoreCounter
    {
        public int CurrentScore => _currentScore;

        private int _currentScore;


        public void AddScore(int score) =>
            _currentScore += score;
    }
}
