using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders
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
