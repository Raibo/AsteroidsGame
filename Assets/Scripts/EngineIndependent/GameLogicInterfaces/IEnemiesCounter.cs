using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IEnemiesCounter
    {
        event Action AllEnemiesDestroyed;

        void IncreaseEnemyCount();
        void DecreaseEnemyCount();
    }
}
