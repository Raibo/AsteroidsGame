using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle
{
    public interface INewGameHandler
    {
        event Action NewGameStarted;
        public void StartNewGame();
    }
}
