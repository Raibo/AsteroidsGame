using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    public class DestroyOnCollisionHolder : EntityHolder<ICollisionHandler>, IInitializedAfterFabrication
    {
        public EntityHolder<IDestroyable> Destroyable;
        public EntityHolder<IScoreCounter> ScoreCounter;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;
        public int ScoreForDestruction;
        public CollisionLayers DestroyedByLayers;

        public override ICollisionHandler Entity => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        public void Initialize()
        {
            _collisionHandler = new DestroyOnCollisionHandler(Destroyable.Entity, ScoreCounter.Entity,
                DestroyedByLayers, EnemiesCounter?.Entity, ScoreForDestruction);
        }


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref Destroyable);

            this.NotifyFieldNotFilledInScene(Destroyable, nameof(Destroyable));
            this.NotifyFieldNotFilledInScene(ScoreCounter, nameof(ScoreCounter));
            this.NotifyFieldNotFilledInScene(EnemiesCounter, nameof(EnemiesCounter));
        }
    }
}
