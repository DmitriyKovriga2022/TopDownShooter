using UnityEngine;

[System.Serializable]
public class AmmoConteiner : ItemConteiner
{
    public AmmoConteiner(int count)
    {
        this.count = count;
    }

    [SerializeField] private int count;

    public override int GetContent()
    {
        return count;
    }

    public void AddingContentValue(int value)
    {
        count += value;
    }
    
    public void SeContentValue(int value)
    {
        count = value;
    }

    public override Sprite GetIcon()
    {
       return StaticData.Instance.itemData.Bullet.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Bullet.Price;
    }
}
