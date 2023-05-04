using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent
{
    public interface IGameOverHandler
    {
        public void DeclareGameOver();
        public event Action<int> GameOverDeclared;
    }
}
