using UnityEngine;

[System.Serializable]
public class FoodConteiner : ItemConteiner
{
    public FoodConteiner(int count)
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
        return StaticData.Instance.itemData.Food.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Food.Price;
    }
}
