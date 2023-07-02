using UnityEngine;

[System.Serializable]
public class ProjectileSetting
{
    public Projectile prefab;
    public GameObject hitEffectPrefab;
    [Range(0.1f, float.MaxValue)]
    public float LiveTime  = 1;
}