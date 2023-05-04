using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities
{
    public class EnemiesCounter : IEnemiesCounter
    {
        public event Action AllEnemiesDestroyed;

        private int _count;


        public void DecreaseEnemyCount()
        {
            _count--;

            if (_count <= 0)
                AllEnemiesDestroyed?.Invoke();
        }


        public void IncreaseEnemyCount() =>
            _count++;
    }
}
