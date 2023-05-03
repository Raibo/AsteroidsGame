using Assets.Scripts.EntityHolders;
using Assets.Scripts.Extensions;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Hudossay.Asteroids.Assets.Scripts.EntityHolders
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class SpaceTeleporterHolder : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public MapBordersProviderHolder MapBordersProviderHolder;

        private SpaceTeleporter _spaceTeleporter;


        private void Start() =>
            _spaceTeleporter = new SpaceTeleporter(RigidBodyWrapper, MapBordersProviderHolder.MapBordersProvider);


        private void FixedUpdate() =>
            _spaceTeleporter.Update();


        private void OnValidate()
        {
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
            this.NotifyFieldNotFilledInScene(MapBordersProviderHolder, nameof(MapBordersProviderHolder));
        }
    }
}
