using Assets.Scripts.EngineIndependent.DataStructs;
using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class DestroyOnCollisionHandler : ICollisionHandler
    {
        private readonly IDestroyable _destroyable;
        private readonly CollisionLayers _destroyingCollisionLayers;


        public DestroyOnCollisionHandler(IDestroyable destroyable, CollisionLayers destroyingCollisionLayers)
        {
            _destroyable = destroyable;
            _destroyingCollisionLayers = destroyingCollisionLayers;
        }


        public void HandleCollision(CollisionLayers otherObjectCollisionLayers)
        {
            if ((otherObjectCollisionLayers & _destroyingCollisionLayers) != CollisionLayers.None)
                _destroyable.Destroy();
        }
    }
}
