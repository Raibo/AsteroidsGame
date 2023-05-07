using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Collisions;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.CollisionHandlers
{
    public interface ICollisionHandler
    {
        public void HandleCollision(CollisionLayers otherObjectCollisionLayer);
    }
}
