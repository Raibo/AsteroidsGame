using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    [RequireComponent(typeof(UserInputWrapper))]
    public class MotionControllerHolder : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public UserInputWrapper UserInputWrapper;
        public float SteeringSpeed;
        public float Acceleration;
        public float MaxSpeed;

        private MotionController _motionController;


        public void Awake()
        {
            _motionController = new MotionController(RigidBodyWrapper, UserInputWrapper,
                SteeringSpeed, Acceleration, MaxSpeed);
        }


        private void FixedUpdate() =>
            _motionController.Update(Time.deltaTime);


        private void OnValidate()
        {
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
            UserInputWrapper = GetComponent<UserInputWrapper>();
        }
    }
}
