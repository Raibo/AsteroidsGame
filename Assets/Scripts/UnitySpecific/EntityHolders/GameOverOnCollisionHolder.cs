using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameEntities;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders;

namespace Assets.Scripts.EntityHolders
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
