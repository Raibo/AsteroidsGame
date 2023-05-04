using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;

namespace Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface ICollisionHandler
    {
        public void HandleCollision(CollisionLayers otherObjectCollisionLayer);
    }
}
