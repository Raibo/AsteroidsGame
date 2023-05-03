using Assets.Scripts.EngineIndependent.GameLogicInterfaces;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class BulletInitializationHolder : MonoBehaviour, IInitializable
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public float Speed;


        public void Initialise() =>
            RigidBodyWrapper.PushForward(Speed);


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
