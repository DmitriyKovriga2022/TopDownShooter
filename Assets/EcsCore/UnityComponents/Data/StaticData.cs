using DialogueEditor;
using UnityEngine;

[CreateAssetMenu]
internal class StaticData : ScriptableObject
{
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
    private static StaticData instance;

    public Vector3 followOffset;
    public float smoothTime;

    public UnitData unitData;
    public ProjectileSetting projectileSetting;
    
    public SpriteCollisionData spriteCollisionData;
    public GridData gridData;
    public TileData tileData;
    public Ai aiPrefab;
    public UnityComponent.SceneItem sceneItemPrefab;
    public UnityComponent.SceneItemMarker sceneItemMarkerPrefab;
    public InteractionObject interactionObjectPrefab;
    public NPCConversation merchantConversation;
    public UIInventoryPanel inventoryPrefab;
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