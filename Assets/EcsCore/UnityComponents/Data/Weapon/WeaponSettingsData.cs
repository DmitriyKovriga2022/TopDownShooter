using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSettingsData
{
    public UnityComponent.Weapon weaponPrefab;
    public SoundClips sound;
    //public float projectileSpeed;
    //public float projectileRadius;
    public int weaponDamage;
    //public int currentInMagazine;
    public int maxInMagazine;

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip[] shootClip;
        public AudioClip[] reloadClip;
        public AudioClip[] misfireClip;
    }

}
