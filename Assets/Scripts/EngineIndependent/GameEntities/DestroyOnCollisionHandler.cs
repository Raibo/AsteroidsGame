using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class DestroyOnCollisionHandler : ICollisionHandler
    {
        private readonly IDestroyable _destroyable;
        private readonly IScoreCounter _scoreCounter;
        private readonly CollisionLayers _destroyingCollisionLayers;
        private readonly IEnemiesCounter _enemiesCounter;
        private readonly int _scoreForDestruction;

        public DestroyOnCollisionHandler(IDestroyable destroyable, IScoreCounter scoreCounter, CollisionLayers destroyingCollisionLayers,
            IEnemiesCounter enemiesCounter, int scoreForDestruction)
        {
            _destroyable = destroyable;
            _scoreCounter = scoreCounter;
            _destroyingCollisionLayers = destroyingCollisionLayers;
            _enemiesCounter = enemiesCounter;
            _scoreForDestruction = scoreForDestruction;
        }


        public virtual void HandleCollision(CollisionLayers otherObjectCollisionLayers)
        {
            if ((otherObjectCollisionLayers & _destroyingCollisionLayers) != CollisionLayers.None)
            {
                _scoreCounter.AddScore(_scoreForDestruction);
                _enemiesCounter?.DecreaseEnemyCount();
                _destroyable.Destroy();
            }
        }
    }
}
