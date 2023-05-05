using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.RandomProviders;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class EnemyInitializerHolder : EntityHolder<IInitializable>, IInitializedAfterFabrication
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public float MinimumSpeed;
        public float MaximumSpeed;
        public float MinimumRotation;
        public float MaximumRotation;
        public override IInitializable Entity => _initializable;

        private IInitializable _initializable;


        public void Initialize() =>
            _initializable.Initialize();


        private void Awake()
        {
            _initializable = new EnemyInitializer(PhysicsObject.Entity, new SystemRandomProvider(), MinimumSpeed, MaximumSpeed,
                MinimumRotation, MaximumRotation);
        }


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref PhysicsObject);
            this.NotifyFieldNotFilled(PhysicsObject, nameof(PhysicsObject));
        }
    }
}
