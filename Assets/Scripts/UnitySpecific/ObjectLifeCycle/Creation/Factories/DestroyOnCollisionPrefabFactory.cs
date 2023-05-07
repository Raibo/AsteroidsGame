using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation.Factories;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics.CollisionHandlers;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class DestroyOnCollisionPrefabFactory : PrefabInstantiationWrapper
    {
        protected override void AssignComponentsFields(GameObject newObject)
        {
            newObject.GetComponent<MapBordersTeleporterHolder>().MapBordersProvider = MapBordersProvider;

            var destroyOnCollisionHolder = newObject.GetComponent<DestroyOnCollisionHolder>();
            destroyOnCollisionHolder.ScoreCounter = ScoreCounter;
            destroyOnCollisionHolder.EnemiesCounter = EnemiesCounter;
        }
    }
}
