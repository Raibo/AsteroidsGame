using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLifeCycle;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.CollisionHandlers
{
    public class GameOverOnCollisionHolder : EntityHolder<ICollisionHandler>
    {
        public EntityHolder<IGameOverHandler> GameOverHandler;
        public CollisionLayers DestroyedByLayers;

        public override ICollisionHandler Entity => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        private void Awake() =>
            _collisionHandler = new GameOverOnCollisionHandler(DestroyedByLayers, GameOverHandler.Entity);


        [ContextMenu("Revalidate")]
        private void OnValidate() =>
            this.NotifyFieldNotFilledInScene(GameOverHandler, nameof(GameOverHandler));
    }
}
