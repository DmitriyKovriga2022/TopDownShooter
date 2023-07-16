using DialogueEditor;
using UnityEngine;

[CreateAssetMenu]
internal class StaticData : ScriptableObject
{
   private static StaticData instance;
    public static StaticData Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load("Configuration") as StaticData;
            }

            return instance;
        }
    }

    public Vector3 followOffset;
    public float smoothTime;

    public UnitData unitData;
    public ProjectileSetting projectileSetting;
    public WeaponSettingsData weaponSettings;
    public SpriteCollisionData spriteCollisionData;
    public ItemData itemData;
    public GridData gridData;
    public TileData tileData;
    public UnityComponent.SceneItem sceneItemPrefab;
    public UnityComponent.SceneItemMarker sceneItemMarkerPrefab;
    public InteractionObject interactionObjectPrefab;
    public NPCConversation merchantConversation;

}

[System.Serializable]
public class ItemData
{
    public ItemConfig Box;
    public ItemConfig Medkit;
    public ItemConfig Bag;
    public ItemConfig Bullet;
    public ItemConfig Food;
    public ItemConfig Jacket;
    public ItemConfig Weapon;
    public ItemConfig Head;
    public SoundClips sound;
    

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip[] inspectItem;
        public AudioClip[] destroyItem;
    }

    [System.Serializable]
    public class ItemConfig
    {
        public string Name;
        public Sprite Sprite;
        public int Price;

    }

}


[System.Serializable]
public class UnitData
{
    public UnityComponent.Unit unitPrefab;
    public UnityComponent.UnitSceneMarker unitMarkerPrefab;
    public float unitSpeed;
    public SoundClips sound;

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip[] hit;
        public AudioClip[] dead;
    }

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

[System.Serializable]
public class SpriteCollisionData
{
    public Sprite exitPointSprite;
}