using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSettingsData
{
    public GameObject projectilePrefab;
    public Transform projectileSocket;
    public float projectileSpeed;
    public float projectileRadius;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;
}
