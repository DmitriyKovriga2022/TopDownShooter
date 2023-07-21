using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsComponent
{
    /// <summary>
    /// Текущая экипировка
    /// </summary>
    public struct EquipWeaponMain
    {
        public int configIndex;
        public int wearout;
        public UnityComponent.Weapon WeaponGo;
        public int weaponDamage;
        public int currentInMagazine;
        public int maxInMagazine;
        public Transform shootPosition;
    }
}
