using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using UnityEngine;
using UnityEngine.UI;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    public class GameOverHandlerHolder : EntityHolder<IGameOverHandler>
    {
        public ScoreCounterHolder ScoreCounter;
        public Text GameOverMessage;

        public override IGameOverHandler Entity => _gameOverHandler;

        private IGameOverHandler _gameOverHandler;


        public void Awake()
        {
            _gameOverHandler = new GameOverHandler(ScoreCounter.Entity);
            _gameOverHandler.GameOverDeclared += OnGameOver;
        }


        private void OnGameOver(int score)
        {
            GameOverMessage.text = $"Game Over\nScore: {score}";
            GameOverMessage.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }


        private void OnDestroy() =>
            _gameOverHandler.GameOverDeclared -= OnGameOver;
    }
}
