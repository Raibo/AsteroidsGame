using Hudossay.Asteroids.Assets.Scripts.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Hudossay.Asteroids.Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class MotionControllerHolder : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public float SteeringSpeed;
        public float Acceleration;
        public float MaxSpeed;

        private MotionController _motionController;


        public void Awake() =>
            _motionController = new MotionController(RigidBodyWrapper, SteeringSpeed, Acceleration, MaxSpeed);


        private void Update()
        {
            CheckKeyDown();
            CheckKeyUp();
        }


        private void FixedUpdate() =>
            _motionController.Update(Time.deltaTime);


        private void CheckKeyDown()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _motionController.StartSteeringLeft();

            if (Input.GetKeyDown(KeyCode.D))
                _motionController.StartSteeringRight();

            if (Input.GetKeyDown(KeyCode.W))
                _motionController.StartAccelerating();
        }


        private void CheckKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.A))
                _motionController.StopSteering();

            if (Input.GetKeyUp(KeyCode.D))
                _motionController.StopSteering();

            if (Input.GetKeyUp(KeyCode.W))
                _motionController.StopAccelerating();
        }


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
