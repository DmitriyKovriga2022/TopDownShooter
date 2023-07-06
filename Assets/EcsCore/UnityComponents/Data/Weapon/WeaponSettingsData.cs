using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSettingsData
{
    public UnityComponent.Weapon weaponPrefab;
    public GameObject projectilePrefab;
    public Transform projectileSocket;
    public SoundClips sound;
    public float projectileSpeed;
    public float projectileRadius;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip shootClip;
        public AudioClip reloadClip;
        public AudioClip misfireClip;
    }

}
