﻿using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Physics
{
    public class MapBordersTeleporterHolder : EntityHolder<MapBordersTeleporter>
    {
        public EntityHolder<IPhysicsObject> PhysicsObject;
        public EntityHolder<IMapBordersProvider> MapBordersProvider;

        public override MapBordersTeleporter Entity => _mapBordersTeleporter;

        private MapBordersTeleporter _mapBordersTeleporter;


        private void Start() =>
            _mapBordersTeleporter = new MapBordersTeleporter(PhysicsObject.Entity, MapBordersProvider.Entity);


        private void FixedUpdate() =>
            _mapBordersTeleporter.Update();


        [ContextMenu("Revalidate")]
        private void OnValidate()
        {
            this.AssignIfEmpty(ref PhysicsObject);

            this.NotifyFieldNotFilledInScene(PhysicsObject, nameof(PhysicsObject));
            this.NotifyFieldNotFilledInScene(MapBordersProvider, nameof(MapBordersProvider));
        }
    }
}
