using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle
{
    public interface IGameOverHandler
    {
        public void DeclareGameOver();
        public event Action GameOverDeclared;
    }
}
