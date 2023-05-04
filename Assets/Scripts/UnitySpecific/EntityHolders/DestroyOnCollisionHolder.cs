using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.Extensions;
using Assets.Scripts.Wrappers;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
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
