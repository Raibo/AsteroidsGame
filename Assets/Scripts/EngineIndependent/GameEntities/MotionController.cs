using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Hudossay.Asteroids.Assets.Scripts.GameEntities
{
    public class MotionController
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly float _steeringSpeed;
        private readonly float _acceleration;
        private readonly float _maxSpeed;

        private SteeringDirection _steeringDirection = SteeringDirection.None;
        private bool _isAccelerating;


        public MotionController(IPhysicsObject physicsObject, float steeringSpeed, float acceleration, float maxSpeed)
        {
            _physicsObject = physicsObject;
            _steeringSpeed = steeringSpeed;
            _acceleration = acceleration;
            _maxSpeed = maxSpeed;
        }


        public void Update(float time)
        {
            RotateBySteering(time);
            Accelerate(time);
        }


        public void StartSteeringLeft() =>
            _steeringDirection |= SteeringDirection.Left;


        public void StartSteeringRight() =>
            _steeringDirection |= SteeringDirection.Right;


        public void StopSteeringLeft() =>
            _steeringDirection &= ~SteeringDirection.Left;


        public void StopSteeringRight() =>
            _steeringDirection &= ~SteeringDirection.Right;


        public void StartAccelerating() =>
            _isAccelerating = true;


        public void StopAccelerating() =>
            _isAccelerating = false;


        private void RotateBySteering(float time)
        {
            switch (_steeringDirection)
            {
                case SteeringDirection.None:
                case SteeringDirection.All:
                    return;
                case SteeringDirection.Left:
                    _physicsObject.Rotation += time * _steeringSpeed;
                    break;
                case SteeringDirection.Right:
                    _physicsObject.Rotation -= time * _steeringSpeed;
                    break;
            }
        }


        private void Accelerate(float time)
        {
            if (!_isAccelerating)
                return;

            _physicsObject.PushForward(time * _acceleration);
            _physicsObject.EnforceSpeedLimit(_maxSpeed);
        }
    }
}
