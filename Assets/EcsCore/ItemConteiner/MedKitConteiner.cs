using UnityEngine;

[System.Serializable]
public class MedKitConteiner : ItemConteiner
{
    public MedKitConteiner(int count)
    {
        this.count = count;
    }
    private int count;
    public override int GetContent()
    {
        return count;
    }

    public override Sprite GetIcon()
    {
        return StaticData.Instance.itemData.medkitSprite;
    }

}
