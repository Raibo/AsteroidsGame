using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.GameLifeCycle
{
    public class GameStateWrapper : EntityHolder<IGameStateHandler>, IGameStateHandler
    {
        public bool IsPaused { get; private set; }
        public GameState GameState { get; set; }
        public override IGameStateHandler Entity => this;

        private const float PausedTimeScale = 0f;
        private const float UnpausedTimeScale = 1f;


        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = PausedTimeScale;
        }



        public void Unpause()
        {
            IsPaused = false;
            Time.timeScale = UnpausedTimeScale;
        }
    }
}
