using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation
{
    public class HomingControllerHolder : MonoBehaviour, IInitializable
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public RigidBodyWrapper TargetRigidBodyWrapper;
        public MapBordersProviderHolder MapBordersProviderHolder;
        public float HomingSpeed;

        private HomingController _homingController;


        public void Initialize()
        {
            _homingController = new HomingController(RigidBodyWrapper, TargetRigidBodyWrapper, MapBordersProviderHolder.MapBordersProvider,
                HomingSpeed);
        }


        private void FixedUpdate() =>
            _homingController.Update();
    }
}
