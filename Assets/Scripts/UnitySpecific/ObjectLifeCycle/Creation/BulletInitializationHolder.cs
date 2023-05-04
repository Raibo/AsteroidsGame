using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.ObjectLifeCycle.Creation;
using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.ObjectLifeCycle.Creation
{
    public class BulletInitializationHolder : EntityHolder<IInitializable>, IInitializedAfterFabrication
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public float Speed;
        public override IInitializable Entity => _initializable;

        private IInitializable _initializable;


        public void Initialize() =>
            _initializable.Initialize();


        private void Awake() =>
            _initializable = new BulletInitializer(PhysicsObject.Entity, Speed);


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref PhysicsObject);
            this.NotifyFieldNotFilledInScene(PhysicsObject, nameof(PhysicsObject));
        }
    }
}
