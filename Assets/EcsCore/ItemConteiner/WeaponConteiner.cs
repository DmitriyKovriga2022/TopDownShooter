using UnityEngine;

[System.Serializable]
public class WeaponConteiner : ItemConteiner
{
    public WeaponConteiner(int count)
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
        return StaticData.Instance.itemData.Weapon.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Weapon.Price;
    }
}
