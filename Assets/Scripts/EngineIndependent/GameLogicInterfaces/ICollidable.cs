using Assets.Scripts.EngineIndependent.DataStructs;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface ICollidable
    {
        void CollideWith(CollisionLayers collisionLayer);
    }
}
