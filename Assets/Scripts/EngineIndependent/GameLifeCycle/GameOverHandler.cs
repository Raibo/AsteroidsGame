using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle
{
    public class GameOverHandler : IGameOverHandler
    {
        public event Action GameOverDeclared;

        private readonly IGameStateHandler _gameStateHandler;


        public GameOverHandler(IGameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
        }


        public void DeclareGameOver()
        {
            _gameStateHandler.GameState = GameState.Finished;
            _gameStateHandler.Pause();

            GameOverDeclared?.Invoke();
        }
    }
}
