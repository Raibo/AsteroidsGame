using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class SplitOnCollisionPrefabFactory : PrefabInstantiationWrapper
    {
        public ObjectFactoryWrapper ShardsFactory;


        protected override void AssignComponentsFields(GameObject newObject)
        {
            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProviderHolder = MapBordersProviderHolder;

            var splitOnCollisionHolder = newObject.GetComponent<SplitInShardsOnCollisionHolder>();
            splitOnCollisionHolder.ScoreCounterHolder = ScoreCounterHolder;
            splitOnCollisionHolder.EnemiesCounterHolder = EnemiesCounterHolder;
            splitOnCollisionHolder.EnemyFactory = ShardsFactory;
        }
    }
}
