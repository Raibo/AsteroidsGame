using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.RandomProviders;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;
using UnityVector2 = UnityEngine.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class EnemySpawnerHolder : MonoBehaviour
    {
        public Transform Transform;
        public EntityHolder<IObjectFactory> EnemyFactory;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;
        public float MinimumInterval;
        public float MaximumInterval;
        public int EnemyLimit;

        private EnemySpawner _enemySpawner;


        private void Awake()
        {
            _enemySpawner = new EnemySpawner(new Timer(), EnemyFactory.Entity, EnemiesCounter.Entity, new SystemRandomProvider(),
                ((UnityVector2)Transform.position).ToAsteroidsVector2(), MinimumInterval, MaximumInterval, EnemyLimit);
        }


        private void FixedUpdate() =>
            _enemySpawner.Update(Time.deltaTime);


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            Transform = transform;
            this.NotifyFieldNotFilled(EnemyFactory, nameof(EnemyFactory));
            this.NotifyFieldNotFilled(EnemiesCounter, nameof(EnemiesCounter));
        }
    }
}
