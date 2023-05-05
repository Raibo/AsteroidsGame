using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Destruction
{
    public class LifetimeLimiter
    {
        private readonly ITimer _timer;
        private readonly IDestroyable _destroyable;


        public LifetimeLimiter(ITimer timer, IDestroyable destroyable, float lifetime)
        {
            _timer = timer;
            _destroyable = destroyable;
            _timer.StartCountdown(lifetime);
        }


        public void Update(float time)
        {
            _timer.Update(time);

            if (_timer.IsFinished)
                _destroyable.Destroy();
        }
    }
}
