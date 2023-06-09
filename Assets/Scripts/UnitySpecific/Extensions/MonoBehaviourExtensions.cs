﻿using UnityEngine;

namespace Hudossay.Asteroids.UnitySpecific.Assets.Scripts.UnitySpecific.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void NotifyFieldNotFilled(this MonoBehaviour mono, object referenceField, string fieldName)
        {
            if (referenceField == null)
                Debug.LogWarning($"GameObject {mono.name} need value for its field {fieldName}", mono);
        }


        public static void NotifyFieldNotFilledInScene(this MonoBehaviour mono, object referenceField, string fieldName)
        {
            if (mono.gameObject.scene.name != null && referenceField == null)
                Debug.LogWarning($"GameObject {mono.name} need value for its field {fieldName}", mono);
        }


        public static void AssignIfEmpty<T>(this MonoBehaviour mono, ref T referenceField) where T : Component
        {
            if (referenceField == null && mono.gameObject.TryGetComponent<T>(out var value))
                referenceField = value;
        }
    }
}
