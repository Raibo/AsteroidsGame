using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Assets.Scripts.EntityHolders;
using Assets.Scripts.Extensions;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.EntityHolders;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.EntityHolders;
using System.Collections.Generic;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs.Vector2;

namespace Assets.Scripts.Wrappers
{
    public class PrefabInstantiationWrapper : ObjectFactoryWrapper
    {
        public GameObject Prefab;
        public MapBordersProviderHolder MapBordersProviderHolder;
        public ScoreCounterHolder ScoreCounterHolder;
        public EnemiesCounterHolder EnemiesCounterHolder;

        private static List<IInitializable> _initializableBuffer;


        public override void Create(AsteroidsVector2 origin, AsteroidsVector2 velocity, float rotation)
        {
            var UnityVectorOrigin = origin.ToUnityVector2();

            var newObject = Instantiate(Prefab);
            newObject.transform.position = UnityVectorOrigin;

            var physicsObject = newObject.GetComponent<IPhysicsObject>();
            physicsObject.Rotation = rotation;
            physicsObject.Velocity = velocity;

            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProviderHolder = MapBordersProviderHolder;

            var destroyOnCollisionHolder = newObject.GetComponent<DestroyOnCollisionHolder>();
            destroyOnCollisionHolder.ScoreCounterHolder = ScoreCounterHolder;
            destroyOnCollisionHolder.EnemiesCounterHolder = EnemiesCounterHolder;

            newObject.GetComponents(_initializableBuffer);

            foreach (IInitializable initializable in _initializableBuffer)
                initializable.Initialize();
        }


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
