﻿using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Collisions;
using Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions;
using System.Linq;
using UnityEngine;
using AsteroidsVector2 = Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics.Vector2;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Collisions
{
    public class CircleCastWrapper : MonoBehaviour, ILaserColliderProvider
    {
        public LayerMask Layer;

        private const float CastDistance = 15f;

        public ICollidable[] GetHitObjects(AsteroidsVector2 origin, AsteroidsVector2 direction, float width)
        {
            var hits = Physics2D.CircleCastAll(origin.ToUnityVector2(), width, direction.ToUnityVector2(), CastDistance, Layer);
            
            return hits.Select(h => h.transform.GetComponent<ICollidable>())
                .Where(h => h != null)
                .ToArray();
        }
    }
}