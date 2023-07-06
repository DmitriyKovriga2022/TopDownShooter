using UnityEngine;

[CreateAssetMenu]
internal class StaticData : ScriptableObject
{
    public UnityComponent.Unit unitPrefab;
    public float unitSpeed;
    public Vector3 followOffset;
    public float smoothTime;

    public ProjectileSetting projectileSetting;
    public WeaponSettingsData weaponSettings;
    public GridData gridData;
    public TileData tileData;
}

[System.Serializable]
public struct GridData
{
    public Vector2Int GridSize;
    public int CellSize;
    public GameObject cellPrefab;
}

[System.Serializable]
public struct GridCell
{
    public Vector2Int Position;
    public Vector2 WorldPosition;
    public Sprite currentSprite;
    public GameObject gameObject;
}

[System.Serializable]
public class TileData
{
    public Sprite[] groundGrass;
}