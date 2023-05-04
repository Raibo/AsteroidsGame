using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent
{
    public class GameOverHandler : IGameOverHandler
    {
        public event Action<int> GameOverDeclared;

        private readonly IScoreCounter _scoreCounter;


        public GameOverHandler(IScoreCounter scoreCounter) =>
            _scoreCounter = scoreCounter;


        public void DeclareGameOver() =>
            GameOverDeclared?.Invoke(_scoreCounter.CurrentScore);
    }
}
