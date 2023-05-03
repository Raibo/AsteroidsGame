using Assets.Scripts.EngineIndependent.DataStructs;

namespace Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface ICollisionHandler
    {
        public void HandleCollision(CollisionLayers otherObjectCollisionLayer);
    }
}
