﻿using System;
using System.Collections.Generic;
using MC.Controlers;
using ModelCore;
using UnityEngine;

namespace Services
{
    public class C_WeaponProjectTile : MonoBehaviour
    {
        public EntityRef ShipEntity;
        public EntityRef BulletEntity;
        public C_ProjectTile Prefab;
        public List<WeaponProjectTile> Weapons;

        public Collider[] CollidersForIgonore;

        private void Awake() => Weapons.ForEach(x => x.Init(CollidersForIgonore));

        private void Start()
        {
            
        }

        public void Fire()
        {
            if(enabled) Weapons.ForEach(x => x.TryFire(ShipEntity.Component, BulletEntity.Component, Prefab));
        }
    }
}