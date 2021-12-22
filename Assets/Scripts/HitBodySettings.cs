using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "HitBodySettings", menuName = "CreateHitBody", order = 0)]
    public class HitBodySettings : ScriptableObject
    {
        [SerializeField] private LayerMask whatToHitMask;
        public LayerMask WhatToHitMask
        {
            get => whatToHitMask;
            private set => whatToHitMask = value;
        }
    }
}