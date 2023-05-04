using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters
{
    public class EnemiesCounterHolder : MonoBehaviour
    {
        public IEnemiesCounter EnemiesCounter => GetEnemiesCounter();

        private IEnemiesCounter _enemiesCounter;


        private IEnemiesCounter GetEnemiesCounter()
        {
            _enemiesCounter ??= new EnemiesCounter();
            return _enemiesCounter;
        }
    }
}
