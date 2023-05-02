using Assets.Scripts.Wrappers;
using Hudossay.Asteroids.Assets.Scripts.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Hudossay.Asteroids.Assets.Scripts.EntityHolders
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

        public MotionController _motionController;


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
