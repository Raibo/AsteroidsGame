namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IEnemiesCounter
    {
        public int Count { get; }
        void IncreaseEnemyCount();
        void DecreaseEnemyCount();
    }
}
