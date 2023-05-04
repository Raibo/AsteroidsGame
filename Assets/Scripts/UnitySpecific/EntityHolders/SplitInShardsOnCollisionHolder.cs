using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.Extensions;
using Assets.Scripts.Wrappers;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
