using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    [RequireComponent(typeof(DestroyableWrapper))]
    public class SplitInShardsOnCollisionHolder : CollisionHandlerHolder, IInitializable
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public ObjectFactoryWrapper EnemyFactory;
        public DestroyableWrapper DestroyableWrapper;
        public ScoreCounterHolder ScoreCounterHolder;
        public EnemiesCounterHolder EnemiesCounterHolder;
        public int ScoreForDestruction;
        public CollisionLayers DestroyedByLayers;
        public override ICollisionHandler CollisionHandler => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        public void Initialize()
        {
            _collisionHandler = new SplitInShardsCollisionHandler(DestroyableWrapper, ScoreCounterHolder.ScoreCounter, DestroyedByLayers,
                EnemiesCounterHolder?.EnemiesCounter, EnemyFactory, RigidBodyWrapper, ScoreForDestruction);
        }


        private void OnValidate()
        {
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
            DestroyableWrapper = GetComponent<DestroyableWrapper>();
            this.NotifyFieldNotFilledInScene(ScoreCounterHolder, nameof(ScoreCounterHolder));
        }
    }
}
