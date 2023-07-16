using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsComponent
{
    public struct EquipWeapon
    {
        public UnityComponent.Weapon WeaponGo;
        public int weaponDamage;
        public int currentInMagazine;
        public int maxInMagazine;
        public Transform shootPosition;
    }
}
