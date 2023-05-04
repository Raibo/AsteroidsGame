using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    public class SplitInShardsOnCollisionHolder : EntityHolder<ICollisionHandler>, IInitializedAfterFabrication
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IObjectFactory> EnemyFactory;
        public EntityHolder<IDestroyable> Destroyable;
        public EntityHolder<IScoreCounter> ScoreCounter;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;
        public int ScoreForDestruction;
        public CollisionLayers DestroyedByLayers;

        public override ICollisionHandler Entity => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        public void Initialize()
        {
            _collisionHandler = new SplitInShardsCollisionHandler(Destroyable.Entity, ScoreCounter.Entity,
                DestroyedByLayers, EnemiesCounter?.Entity, EnemyFactory.Entity, PhysicsObject.Entity, ScoreForDestruction);
        }


        private void OnValidate()
        {
            this.NotifyFieldNotFilledInScene(PhysicsObject, nameof(PhysicsObject));
            this.NotifyFieldNotFilledInScene(Destroyable, nameof(Destroyable));
            this.NotifyFieldNotFilledInScene(ScoreCounter, nameof(ScoreCounter));
        }
    }
}
