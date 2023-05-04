using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Counters;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using System.Collections.Generic;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation.Factories
{
    public abstract class PrefabInstantiationWrapper : EntityHolder<IObjectFactory>, IObjectFactory
    {
        public GameObject Prefab;
        public EntityHolder<IMapBordersProvider> MapBordersProvider;
        public EntityHolder<IScoreCounter> ScoreCounter;
        public EntityHolder<IEnemiesCounter> EnemiesCounter;

        public override IObjectFactory Entity => this;

        private static List<IInitializedAfterFabrication> _initializableBuffer;


        public void Create(AsteroidsVector2 origin, AsteroidsVector2 velocity, float rotation)
        {
            var newObject = Instantiate(Prefab);
            newObject.transform.position = origin.ToUnityVector2();

            var physicsObject = newObject.GetComponent<IPhysicsObject>();
            physicsObject.Rotation = rotation;
            physicsObject.Velocity = velocity;

            AssignComponentsFields(newObject);

            newObject.GetComponents(_initializableBuffer);

            foreach (IInitializedAfterFabrication initializedComponent in _initializableBuffer)
                initializedComponent.Initialize();

            EnemiesCounter?.Entity.IncreaseEnemyCount();
        }


        protected abstract void AssignComponentsFields(GameObject newObject);


        private void Awake() =>
            _initializableBuffer = new List<IInitializedAfterFabrication>();


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.NotifyFieldNotFilled(Prefab, nameof(Prefab));
            this.NotifyFieldNotFilled(MapBordersProvider, nameof(MapBordersProvider));
            this.NotifyFieldNotFilled(ScoreCounter, nameof(ScoreCounter));
        }
    }
}
