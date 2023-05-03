using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;

namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IObjectFactory
    {
        public void Create(Vector2 origin, Vector2 velocity, float rotation);
    }
}
