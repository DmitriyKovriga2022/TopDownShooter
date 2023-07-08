using UnityEngine;

[System.Serializable]
public class ProjectileSetting
{
    public UnityComponent.Projectile prefab;
    public GameObject hitEffectPrefab;
    [Range(0.1f, float.MaxValue)]
    public float LiveTime  = 1;
    public LayerMask hitMask;
    public SoundClips sound;

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip[] groundHit;
        public AudioClip[] groundRicochet;
    }
}