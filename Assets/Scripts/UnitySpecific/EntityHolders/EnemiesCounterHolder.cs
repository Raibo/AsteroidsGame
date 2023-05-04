using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders
{
    public class EnemiesCounterHolder : MonoBehaviour
    {
        public IEnemiesCounter EnemiesCounter;


        private void Awake() =>
            EnemiesCounter = new EnemiesCounter();
    }
}
