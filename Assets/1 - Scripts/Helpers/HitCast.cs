﻿using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using UltEvents;
using UnityEngine;

namespace Services
{
    public class HitCast : MonoBehaviour
    {
        [SerializeField] private bool _isForward;
        [Min(0)][SerializeField] private float _distance;

        public LayerMask Mask;
        private HashSet<Collider> _collidersForIgnore = new HashSet<Collider>();
        public UltEvent<Collider> Hited;

        public void AddIgnore(Collider[] colliders) => colliders.ForEach(x => _collidersForIgnore.Add(x));
        
        public bool IsForward
        {
            get => _isForward;
            set => _isForward = value;
        }


        private void Update()
        {
            if(Physics.Raycast(transform.position, (IsForward ? transform.forward : transform.forward * -1), out var info, _distance, Mask))
                if(!_collidersForIgnore.Contains(info.collider))
                    Hited.Invoke(info.collider);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + (IsForward ? transform.forward : transform.forward * -1)*_distance);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _distance);
        }
    }
}