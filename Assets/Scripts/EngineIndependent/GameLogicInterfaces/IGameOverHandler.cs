using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IGameOverHandler
    {
        public void DeclareGameOver();
        public event Action<int> GameOverDeclared;
    }
}
