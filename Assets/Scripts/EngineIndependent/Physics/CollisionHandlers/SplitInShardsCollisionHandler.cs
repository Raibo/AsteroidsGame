using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers
{
    public class SplitInShardsCollisionHandler : DestroyOnCollisionHandler
    {
        private readonly IObjectFactory _shardsFactory;
        private readonly IPhysicsObject _physicsObject;
        private readonly int _shardsCount;


        public SplitInShardsCollisionHandler(IDestroyable destroyable, IScoreCounter scoreCounter, CollisionLayers destroyingCollisionLayers,
            IEnemiesCounter enemiesCounter, IObjectFactory shardsFactory, IPhysicsObject physicsObject, int scoreForDestruction, int shardsCount)
            : base(destroyable, scoreCounter, destroyingCollisionLayers, enemiesCounter, scoreForDestruction)
        {
            _shardsFactory = shardsFactory;
            _physicsObject = physicsObject;
            _shardsCount = shardsCount;
        }


        public override void HandleCollision(CollisionLayers otherObjectCollisionLayers)
        {
            if ((otherObjectCollisionLayers & _destroyingCollisionLayers) != CollisionLayers.None)
                CreateShards();

            base.HandleCollision(otherObjectCollisionLayers);
        }


        private void CreateShards()
        {
            for (int i = 0; i < _shardsCount; i++)
                _shardsFactory.Create(_physicsObject.Position, _physicsObject.Velocity, _physicsObject.Rotation);
        }
    }
}
