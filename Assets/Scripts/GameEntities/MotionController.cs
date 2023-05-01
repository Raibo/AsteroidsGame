using Hudossay.Asteroids.Assets.Scripts.DataStructs;
using Hudossay.Asteroids.Assets.Scripts.GameLogicInterfaces;

namespace Hudossay.Asteroids.Assets.Scripts.GameEntities
{
    public class MotionController
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly float _steeringSpeed;
        private readonly float _acceleration;

        private SteeringDirection _steeringDirection = SteeringDirection.None;
        private bool _isAccelerating;


        public MotionController(IPhysicsObject physicsObject, float steeringSpeed, float acceleration)
        {
            _physicsObject = physicsObject;
            _steeringSpeed = steeringSpeed;
            _acceleration = acceleration;
        }


        public void Update(float time)
        {
            RotateBySteering(time);
            Accelerate(time);
        }


        public void StartSteeringLeft() =>
            _steeringDirection = SteeringDirection.Left;


        public void StartSteeringRight() =>
            _steeringDirection = SteeringDirection.Right;


        public void StopSteering() =>
            _steeringDirection = SteeringDirection.None;


        public void StartAccelerating() =>
            _isAccelerating = true;


        public void StopAcceleration() =>
            _isAccelerating = false;


        private void RotateBySteering(float time)
        {
            switch (_steeringDirection)
            {
                case SteeringDirection.None:
                    return;
                case SteeringDirection.Left:
                    _physicsObject.Rotation -= time * _steeringSpeed;
                    break;
                case SteeringDirection.Right:
                    _physicsObject.Rotation += time * _steeringSpeed;
                    break;
            }
        }


        private void Accelerate(float time)
        {
            if (!_isAccelerating)
                return;

            _physicsObject.PushForward(time * _acceleration);
        }
    }
}
