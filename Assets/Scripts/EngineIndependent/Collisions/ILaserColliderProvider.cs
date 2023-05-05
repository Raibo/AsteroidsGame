using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions
{
    public interface ILaserColliderProvider
    {
        int GetHitObjects(Vector2 origin, Vector2 direction, float width, ICollidable[] buffer);
    }
}
