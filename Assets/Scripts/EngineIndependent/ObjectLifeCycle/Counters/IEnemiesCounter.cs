namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
{
    public interface IEnemiesCounter
    {
        public int Count { get; }
        void IncreaseEnemyCount();
        void DecreaseEnemyCount();
    }
}
