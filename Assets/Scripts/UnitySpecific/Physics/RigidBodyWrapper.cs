using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;
using UnityVector2 = UnityEngine.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidBodyWrapper : EntityHolder<IPhysicsObject>, IPhysicsObject
    {
        public Transform Transform;
        public Rigidbody2D Rigidbody2D;

        public override IPhysicsObject Entity => this;

        public AsteroidsVector2 Position
        {
            get => Rigidbody2D.position.ToAsteroidsVector2();
            set => Rigidbody2D.position = value.ToUnityVector2();
        }

        public AsteroidsVector2 Direction => ((UnityVector2)transform.up).ToAsteroidsVector2();

        public float Rotation
        {
            get => Rigidbody2D.rotation;
            set => Rigidbody2D.rotation = value;
        }

        public AsteroidsVector2 Velocity
        {
            get => Rigidbody2D.velocity.ToAsteroidsVector2();
            set => Rigidbody2D.velocity = value.ToUnityVector2();
        }

        public void PushForward(float additionalSpeed) =>
            Rigidbody2D.AddRelativeForce(additionalSpeed * Rigidbody2D.mass * UnityVector2.up, ForceMode2D.Impulse);


        public void EnforceSpeedLimit(float maxSpeed)
        {
            if (Rigidbody2D.velocity.sqrMagnitude < maxSpeed * maxSpeed)
                return;

            Rigidbody2D.velocity = Rigidbody2D.velocity.normalized * maxSpeed;
        }


        private void OnValidate()
        {
            Transform = transform;
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
