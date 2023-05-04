using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using UnityEngine;
using UnityEngine.UI;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    [RequireComponent(typeof(ScoreCounterHolder))]
    public class GameOverHandlerHolder : MonoBehaviour
    {
        public IGameOverHandler GameOverHandler;
        public ScoreCounterHolder ScoreCounterHolder;
        public Text GameOverMessage;


        public void Awake()
        {
            GameOverHandler = new GameOverHandler(ScoreCounterHolder.ScoreCounter);
            GameOverHandler.GameOverDeclared += OnGameOver;
        }


        private void OnGameOver(int score)
        {
            GameOverMessage.text = $"Game Over.\nScore: {score}";
            GameOverMessage.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }


        private void OnDestroy() =>
            GameOverHandler.GameOverDeclared -= OnGameOver;


        private void OnValidate() =>
            ScoreCounterHolder = GetComponent<ScoreCounterHolder>();
    }
}
