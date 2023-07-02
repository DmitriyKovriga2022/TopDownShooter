using Leopotam.Ecs;
using UnityEngine;

namespace EcsComponent
{
    internal struct Weapon
    {
        public EcsEntity owner;
        public int totalAmmo;
        public int weaponDamage;
        public int currentInMagazine;
        public int maxInMagazine;
        public Transform shootPosition;
    }
}