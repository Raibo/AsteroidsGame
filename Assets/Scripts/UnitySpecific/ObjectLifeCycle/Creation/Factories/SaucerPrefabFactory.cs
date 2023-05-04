using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.CollisionHandlers;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class SaucerPrefabFactory : PrefabInstantiationWrapper
    {
        public RigidBodyWrapper HomingTargetPhysicsWrapper;


        protected override void AssignComponentsFields(GameObject newObject)
        {
            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProviderHolder = MapBordersProviderHolder;

            var destroyOnCollisionHolder = newObject.GetComponent<DestroyOnCollisionHolder>();
            destroyOnCollisionHolder.ScoreCounterHolder = ScoreCounterHolder;
            destroyOnCollisionHolder.EnemiesCounterHolder = EnemiesCounterHolder;

            var homingController = newObject.GetComponent<HomingControllerHolder>();
            homingController.TargetRigidBodyWrapper = HomingTargetPhysicsWrapper;
            homingController.MapBordersProviderHolder = MapBordersProviderHolder;
        }
    }
}
