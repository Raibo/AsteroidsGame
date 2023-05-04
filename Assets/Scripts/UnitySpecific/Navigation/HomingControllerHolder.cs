using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation
{
    public class HomingControllerHolder : EntityHolder<HomingController>, IInitializedAfterFabrication
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IPhysicsObject> TargetPhysicsObject;
        public EntityHolder<IMapBordersProvider> MapBordersProvider;
        public float HomingSpeed;

        public override HomingController Entity => _homingController;

        private HomingController _homingController;


        public void Initialize() =>
            _homingController = new HomingController(PhysicsObject.Entity, TargetPhysicsObject.Entity, MapBordersProvider.Entity, HomingSpeed);


        private void FixedUpdate() =>
            _homingController.Update();


        [ContextMenu("Revalidate")]
        private void OnValidate() =>
            this.AssignIfEmpty(ref PhysicsObject);
    }
}
