using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific
{
    [RequireComponent(typeof(ScoreCounterHolder))]
    public class GameOverHandlerHolder : MonoBehaviour
    {
        public IGameOverHandler GameOverHandler;
        public ScoreCounterHolder ScoreCounterHolder;


        public void Awake()
        {
            GameOverHandler = new GameOverHandler(ScoreCounterHolder.ScoreCounter);
            GameOverHandler.GameOverDeclared += OnGameOver;
        }


        private void OnGameOver(int score) =>
            print($"Game over! Score: {score}");


        private void OnDestroy() =>
            GameOverHandler.GameOverDeclared -= OnGameOver;


        private void OnValidate() =>
            ScoreCounterHolder = GetComponent<ScoreCounterHolder>();
    }
}
