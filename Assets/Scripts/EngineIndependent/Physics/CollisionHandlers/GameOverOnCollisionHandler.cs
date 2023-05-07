using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers
{
    public class GameOverOnCollisionHandler : ICollisionHandler
    {
        private readonly CollisionLayers _destroyingCollisionLayers;
        private readonly IGameOverHandler _gameOverHandler;


        public GameOverOnCollisionHandler(CollisionLayers destroyingCollisionLayers, IGameOverHandler gameOverHandler)
        {
            _destroyingCollisionLayers = destroyingCollisionLayers;
            _gameOverHandler = gameOverHandler;
        }


        public void HandleCollision(CollisionLayers otherObjectCollisionLayers)
        {
            if ((otherObjectCollisionLayers & _destroyingCollisionLayers) != CollisionLayers.None)
                _gameOverHandler.DeclareGameOver();
        }
    }
}
