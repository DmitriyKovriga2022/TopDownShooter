using UnityEngine;

[CreateAssetMenu]
internal class StaticData : ScriptableObject
{
    public Unit playerPrefab;
    public float playerSpeed;
    public Vector3 followOffset;
    public float smoothTime;

    public ProjectileSetting projectileSetting;
    public WeaponSettingsData weaponSettings;
}