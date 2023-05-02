using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using UnityEngine;
using MyVector2 = Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs.Vector2;
using UnityVector2 = UnityEngine.Vector2;

namespace Hudossay.Asteroids.Assets.Scripts.Wrappers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidBodyWrapper : MonoBehaviour, IPhysicsObject
    {
        public Rigidbody2D Rigidbody2D;

        public MyVector2 Position
        {
            get => new(Rigidbody2D.position.x, Rigidbody2D.position.y);

            set
            {
                var newPosition = new UnityVector2(value.X, value.Y);
                Rigidbody2D.position = newPosition;
            }
        }

        public float Rotation
        {
            get => Rigidbody2D.rotation;
            set => Rigidbody2D.rotation = value;
        }

        public MyVector2 Velocity
        {
            get => new(Rigidbody2D.velocity.x, Rigidbody2D.velocity.y);

            set
            {
                var newVelocity = new UnityVector2(value.X, value.Y);
                Rigidbody2D.velocity = newVelocity;
            }
        }

        public void PushForward(float additionalSpeed) =>
            Rigidbody2D.AddRelativeForce(additionalSpeed * Rigidbody2D.mass * UnityVector2.up, ForceMode2D.Impulse);


        public void EnforceSpeedLimit(float maxSpeed)
        {
            if (Rigidbody2D.velocity.sqrMagnitude < maxSpeed * maxSpeed)
                return;

            Rigidbody2D.velocity = Rigidbody2D.velocity.normalized * maxSpeed;
        }


        private void OnValidate() =>
            Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
