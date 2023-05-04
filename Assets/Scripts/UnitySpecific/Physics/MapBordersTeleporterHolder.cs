using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics
{
    [RequireComponent(typeof(RigidBodyWrapper))]
    public class MapBordersTeleporterHolder : MonoBehaviour
    {
        public RigidBodyWrapper RigidBodyWrapper;
        public MapBordersProviderHolder MapBordersProviderHolder;

        private MapBordersTeleporter _mapBordersTeleporter;


        private void Start() =>
            _mapBordersTeleporter = new MapBordersTeleporter(RigidBodyWrapper, MapBordersProviderHolder.MapBordersProvider);


        private void FixedUpdate() =>
            _mapBordersTeleporter.Update();


        private void OnValidate()
        {
            RigidBodyWrapper = GetComponent<RigidBodyWrapper>();
            this.NotifyFieldNotFilledInScene(MapBordersProviderHolder, nameof(MapBordersProviderHolder));
        }
    }
}
