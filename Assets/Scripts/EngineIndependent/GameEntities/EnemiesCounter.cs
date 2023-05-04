using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using System;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities
{
    public class EnemiesCounter : IEnemiesCounter
    {
        public int Count => _count;

        private int _count;


        public void DecreaseEnemyCount() =>
            _count--;


        public void IncreaseEnemyCount() =>
            _count++;
    }
}
