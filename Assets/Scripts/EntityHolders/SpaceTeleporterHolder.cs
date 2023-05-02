using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.DataStructs;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Hudossay.Asteroids.Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class SpaceTeleporterHolder : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public Rectangle Rectangle;

        private SpaceTeleporter _spaceTeleporter;


        private void Awake() =>
            _spaceTeleporter = new SpaceTeleporter(RigidBodyWrapper, Rectangle);


        private void FixedUpdate() =>
            _spaceTeleporter.Update();


        private void OnValidate() =>
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
    }
}
