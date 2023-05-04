using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Navigation;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Navigation
{
    public class UserInputWrapper : MonoBehaviour, IControlInputProvider
    {
        public SteeringDirection SteeringDirection => _steeringDirection;
        public bool IsAccelerating => _isAccelerating;
        public bool IsShootingGun => _isShootingGun;
        public bool IsShootingLaser => _isShootingLaser;

        private SteeringDirection _steeringDirection = SteeringDirection.None;
        private bool _isAccelerating;
        private bool _isShootingGun;
        private bool _isShootingLaser;


        private void Update()
        {
            CheckKeyDown();
            CheckKeyUp();
        }


        private void CheckKeyDown()
        {
            if (Input.GetKeyDown(KeyCode.A))
                StartSteeringLeft();

            if (Input.GetKeyDown(KeyCode.D))
                StartSteeringRight();

            if (Input.GetKeyDown(KeyCode.W))
                StartAccelerating();

            if (Input.GetKeyDown(KeyCode.Space))
                StartShootingGun();

            if (Input.GetKeyDown(KeyCode.LeftShift))
                StartShootingLaser();
        }


        private void CheckKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.A))
                StopSteeringLeft();

            if (Input.GetKeyUp(KeyCode.D))
                StopSteeringRight();

            if (Input.GetKeyUp(KeyCode.W))
                StopAccelerating();

            if (Input.GetKeyUp(KeyCode.Space))
                StopShootingGun();

            if (Input.GetKeyUp(KeyCode.LeftShift))
                StopShootingLaser();
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


        public void StartShootingGun() =>
            _isShootingGun = true;


        public void StopShootingGun() =>
            _isShootingGun = false;


        public void StartShootingLaser() =>
            _isShootingLaser = true;


        public void StopShootingLaser() =>
            _isShootingLaser = false;
    }
}
