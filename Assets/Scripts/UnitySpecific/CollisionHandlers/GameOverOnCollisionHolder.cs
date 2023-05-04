using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.CollisionHandlers;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers
{
    public class GameOverOnCollisionHolder : CollisionHandlerHolder
    {
        public GameOverHandlerHolder GameOverHandlerHolder;
        public CollisionLayers DestroyedByLayers;
        public override ICollisionHandler CollisionHandler => _collisionHandler;

        private ICollisionHandler _collisionHandler;


        private void Awake() =>
            _collisionHandler = new GameOverOnCollisionHandler(DestroyedByLayers, GameOverHandlerHolder.GameOverHandler);


        private void OnValidate() =>
            this.NotifyFieldNotFilledInScene(GameOverHandlerHolder, nameof(GameOverHandlerHolder));
    }
}
