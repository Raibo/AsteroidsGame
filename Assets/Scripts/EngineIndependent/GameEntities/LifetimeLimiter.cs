using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class LifetimeLimiter
    {
        private readonly IDestroyable _destroyable;
        private float _remainingLifetime;


        public LifetimeLimiter(IDestroyable destroyable, float lifetime)
        {
            _destroyable = destroyable;
            _remainingLifetime = lifetime;
        }


        public void Update(float time)
        {
            _remainingLifetime -= time;

            if (_remainingLifetime <= 0)
                _destroyable.Destroy();
        }
    }
}
