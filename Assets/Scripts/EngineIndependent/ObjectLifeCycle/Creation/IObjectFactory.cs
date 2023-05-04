using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation
{
    public interface IObjectFactory
    {
        public void Create(Vector2 origin, Vector2 velocity, float rotation);
    }
}
