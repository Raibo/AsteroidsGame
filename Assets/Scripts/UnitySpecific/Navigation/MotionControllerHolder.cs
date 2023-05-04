using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation
{
    public class MotionControllerHolder : EntityHolder<MotionController>
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IControlInputProvider> ControlInputProvider;
        public float SteeringSpeed;
        public float Acceleration;
        public float MaxSpeed;

        public override MotionController Entity => _motionController;

        private MotionController _motionController;


        public void Awake()
        {
            _motionController = new MotionController(PhysicsObject.Entity, ControlInputProvider.Entity,
                SteeringSpeed, Acceleration, MaxSpeed);
        }


        private void FixedUpdate() =>
            _motionController.Update(Time.deltaTime);


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref PhysicsObject);
            this.AssignIfEmpty(ref ControlInputProvider);

            this.NotifyFieldNotFilledInScene(PhysicsObject, nameof(PhysicsObject));
            this.NotifyFieldNotFilledInScene(ControlInputProvider, nameof(ControlInputProvider));
        }
    }
}
