using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.CollisionHandlers
{
    public class SplitInShardsOnCollisionHolder : EntityHolder<ICollisionHandler>, IInitializedAfterFabrication
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IObjectFactory> EnemyFactory;
        public EntityHolder<IDestroyable> Destroyable;
        public EntityHolder<IScoreCounter> ScoreCounter;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;
        public int ScoreForDestruction;
        public int ShardsCount;
        public CollisionLayers DestroyedByLayers;

        public override ICollisionHandler Entity => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        public void Initialize()
        {
            _collisionHandler = new SplitInShardsCollisionHandler(Destroyable.Entity, ScoreCounter.Entity,
                DestroyedByLayers, EnemiesCounter?.Entity, EnemyFactory.Entity, PhysicsObject.Entity, ScoreForDestruction, ShardsCount);
        }


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref PhysicsObject);
            this.AssignIfEmpty(ref EnemyFactory);
            this.AssignIfEmpty(ref Destroyable);

            this.NotifyFieldNotFilledInScene(PhysicsObject, nameof(PhysicsObject));
            this.NotifyFieldNotFilledInScene(EnemyFactory, nameof(EnemyFactory));
            this.NotifyFieldNotFilledInScene(Destroyable, nameof(Destroyable));
            this.NotifyFieldNotFilledInScene(ScoreCounter, nameof(ScoreCounter));
            this.NotifyFieldNotFilledInScene(EnemiesCounter, nameof(EnemiesCounter));
        }
    }
}
