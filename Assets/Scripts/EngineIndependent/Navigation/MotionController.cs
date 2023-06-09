﻿using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation
{
    public class MotionController
    {
        private readonly IPhysicsObject _physicsObject;
        private readonly IControlInputProvider _controlInputProvider;
        private readonly float _steeringSpeed;
        private readonly float _acceleration;
        private readonly float _maxSpeed;


        public MotionController(IPhysicsObject physicsObject, IControlInputProvider controlInputProvider,
            float steeringSpeed, float acceleration, float maxSpeed)
        {
            _physicsObject = physicsObject;
            _controlInputProvider = controlInputProvider;
            _steeringSpeed = steeringSpeed;
            _acceleration = acceleration;
            _maxSpeed = maxSpeed;
        }


        public void Update(float time)
        {
            RotateBySteering(time);
            Accelerate(time);
        }


        private void RotateBySteering(float time)
        {
            switch (_controlInputProvider.SteeringDirection)
            {
                case SteeringDirection.None:
                case SteeringDirection.All:
                    return;
                case SteeringDirection.Left:
                    _physicsObject.Rotation += time * _steeringSpeed;
                    _physicsObject.Rotation %= 360;
                    break;
                case SteeringDirection.Right:
                    _physicsObject.Rotation -= time * _steeringSpeed;
                    _physicsObject.Rotation %= 360;
                    break;
            }
        }


        private void Accelerate(float time)
        {
            if (!_controlInputProvider.IsAccelerating)
                return;

            _physicsObject.PushForward(time * _acceleration);
            _physicsObject.EnforceSpeedLimit(_maxSpeed);
        }
    }
}
