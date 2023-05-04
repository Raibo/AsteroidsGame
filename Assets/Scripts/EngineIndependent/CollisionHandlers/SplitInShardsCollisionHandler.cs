using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers
{
    public class SplitInShardsCollisionHandler : DestroyOnCollisionHandler
    {
        private readonly IObjectFactory _shardsFactory;
        private readonly IPhysicsObject _physicsObject;


        public SplitInShardsCollisionHandler(IDestroyable destroyable, IScoreCounter scoreCounter, CollisionLayers destroyingCollisionLayers,
            IEnemiesCounter enemiesCounter, IObjectFactory shardsFactory, IPhysicsObject physicsObject, int scoreForDestruction)
            : base(destroyable, scoreCounter, destroyingCollisionLayers, enemiesCounter, scoreForDestruction)
        {
            _shardsFactory = shardsFactory;
            _physicsObject = physicsObject;
        }


        public override void HandleCollision(CollisionLayers otherObjectCollisionLayers)
        {
            if ((otherObjectCollisionLayers & _destroyingCollisionLayers) != CollisionLayers.None)
            {
                _shardsFactory.Create(_physicsObject.Position, _physicsObject.Velocity, _physicsObject.Rotation);
                _shardsFactory.Create(_physicsObject.Position, _physicsObject.Velocity, _physicsObject.Rotation);
            }

            base.HandleCollision(otherObjectCollisionLayers);
        }
    }
}
