using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation.Factories;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.CollisionHandlers;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class SplitOnCollisionPrefabFactory : PrefabInstantiationWrapper
    {
        public EntityHolder<IObjectFactory> ShardsFactory;


        protected override void AssignComponentsFields(GameObject newObject)
        {
            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProvider = MapBordersProvider;

            var splitOnCollisionHolder = newObject.GetComponent<SplitInShardsOnCollisionHolder>();
            splitOnCollisionHolder.ScoreCounter = ScoreCounter;
            splitOnCollisionHolder.EnemiesCounter = EnemiesCounter;
            splitOnCollisionHolder.EnemyFactory = ShardsFactory;
        }
    }
}
