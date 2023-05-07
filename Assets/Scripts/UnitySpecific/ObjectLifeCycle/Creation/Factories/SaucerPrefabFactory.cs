using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation.Factories;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.CollisionHandlers;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class SaucerPrefabFactory : PrefabInstantiationWrapper, IObjectFactory
    {
        public EntityHolder<IPhysicsObject> HomingTargetPhysicsObject;


        protected override void AssignComponentsFields(GameObject newObject)
        {
            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProvider = MapBordersProvider;

            var destroyOnCollisionHolder = newObject.GetComponent<DestroyOnCollisionHolder>();
            destroyOnCollisionHolder.ScoreCounter = ScoreCounter;
            destroyOnCollisionHolder.EnemiesCounter = EnemiesCounter;

            var homingController = newObject.GetComponent<HomingControllerHolder>();
            homingController.TargetPhysicsObject = HomingTargetPhysicsObject;
            homingController.MapBordersProvider = MapBordersProvider;
        }
    }
}
