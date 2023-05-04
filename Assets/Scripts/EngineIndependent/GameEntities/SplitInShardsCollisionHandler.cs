using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities
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
            _shardsFactory.Create(_physicsObject.Position, _physicsObject.Velocity, _physicsObject.Rotation);
            base.HandleCollision(otherObjectCollisionLayers);
        }
    }
}
