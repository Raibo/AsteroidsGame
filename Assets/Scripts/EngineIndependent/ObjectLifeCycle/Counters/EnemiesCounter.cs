﻿namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters
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