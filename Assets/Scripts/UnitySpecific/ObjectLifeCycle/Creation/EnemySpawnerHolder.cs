using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class EnemySpawnerHolder : MonoBehaviour
    {
        public Transform Transform;
        public ObjectFactoryWrapper EnemyFactory;
        public EnemiesCounterHolder EnemiesCounterHolder;
        public float MinimumInterval;
        public float MaximumInterval;
        public int EnemyLimit;

        private EnemySpawner _enemySpawner;


        private void Awake()
        {
            _enemySpawner = new EnemySpawner(EnemyFactory, EnemiesCounterHolder.EnemiesCounter, new SystemRandomProvider(),
                ((Vector2)Transform.position).ToAsteroidsVector2(), MinimumInterval, MaximumInterval, EnemyLimit);
        }


        private void FixedUpdate() =>
            _enemySpawner.Update(Time.deltaTime);


        private void OnValidate()
        {
            Transform = transform;
            this.NotifyFieldNotFilled(EnemyFactory, nameof(EnemyFactory));
            this.NotifyFieldNotFilled(EnemiesCounterHolder, nameof(EnemiesCounterHolder));
        }
    }
}
