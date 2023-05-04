using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using System.Collections.Generic;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public abstract class PrefabInstantiationWrapper : ObjectFactoryWrapper
    {
        public GameObject Prefab;
        public MapBordersProviderHolder MapBordersProviderHolder;
        public ScoreCounterHolder ScoreCounterHolder;
        public EnemiesCounterHolder EnemiesCounterHolder;

        private static List<IInitializable> _initializableBuffer;


        public override void Create(AsteroidsVector2 origin, AsteroidsVector2 velocity, float rotation)
        {
            var newObject = Instantiate(Prefab);
            newObject.transform.position = origin.ToUnityVector2();

            var physicsObject = newObject.GetComponent<IPhysicsObject>();
            physicsObject.Rotation = rotation;
            physicsObject.Velocity = velocity;

            AssignComponentsFields(newObject);

            newObject.GetComponents(_initializableBuffer);

            foreach (IInitializable initializable in _initializableBuffer)
                initializable.Initialize();

            EnemiesCounterHolder?.EnemiesCounter.IncreaseEnemyCount();
        }


        protected abstract void AssignComponentsFields(GameObject newObject);


        private void Awake() =>
            _initializableBuffer = new List<IInitializable>();


        private void OnValidate()
        {
            this.NotifyFieldNotFilled(Prefab, nameof(Prefab));
            this.NotifyFieldNotFilled(MapBordersProviderHolder, nameof(MapBordersProviderHolder));
            this.NotifyFieldNotFilled(ScoreCounterHolder, nameof(ScoreCounterHolder));
        }
    }
}
