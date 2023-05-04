using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Destruction;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    [RequireComponent(typeof(DestroyableWrapper))]
    public class DestroyOnCollisionHolder : CollisionHandlerHolder, IInitializable
    {
        public DestroyableWrapper DestroyableWrapper;
        public ScoreCounterHolder ScoreCounterHolder;
        public EnemiesCounterHolder EnemiesCounterHolder;
        public int ScoreForDestruction;
        public CollisionLayers DestroyedByLayers;
        public override ICollisionHandler CollisionHandler => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        public void Initialize()
        {
            _collisionHandler = new DestroyOnCollisionHandler(DestroyableWrapper, ScoreCounterHolder.ScoreCounter, DestroyedByLayers,
                EnemiesCounterHolder?.EnemiesCounter, ScoreForDestruction);
        }


        private void OnValidate()
        {
            DestroyableWrapper = GetComponent<DestroyableWrapper>();
            this.NotifyFieldNotFilledInScene(ScoreCounterHolder, nameof(ScoreCounterHolder));
        }
    }
}
