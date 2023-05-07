using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers
{
    public class DestroyOnCollisionHandler : ICollisionHandler
    {
        protected readonly CollisionLayers _destroyingCollisionLayers;
        private readonly IDestroyable _destroyable;
        private readonly IScoreCounter _scoreCounter;
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
                _enemiesCounter?.RemoveCountedEnemy(_destroyable);
                _destroyable.Destroy();
            }
        }
    }
}
