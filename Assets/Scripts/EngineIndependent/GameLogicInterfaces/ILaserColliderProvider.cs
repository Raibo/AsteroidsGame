using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface ILaserColliderProvider
    {
        ICollidable[] GetHitObjects(Vector2 origin, Vector2 direction, float width);
    }
}
