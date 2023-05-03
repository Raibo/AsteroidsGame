using Assets.Scripts.EntityHolders;
using Assets.Scripts.Extensions;
using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameEntities;
using Hudossay.Asteroids.Assets.Scripts.Wrappers;
using UnityEngine;

namespace Hudossay.Asteroids.Assets.Scripts.EntityHolders
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
