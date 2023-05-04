using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters
{
    public class EnemiesCounterHolder : EntityHolder<IEnemiesCounter>
    {
        public override IEnemiesCounter Entity => GetEnemiesCounter();

        private IEnemiesCounter _enemiesCounter;


        private IEnemiesCounter GetEnemiesCounter()
        {
            _enemiesCounter ??= new EnemiesCounter();
            return _enemiesCounter;
        }
    }
}
