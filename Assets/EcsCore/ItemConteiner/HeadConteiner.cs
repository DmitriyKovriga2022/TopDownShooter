using System.Collections;
using UnityEngine;

public class HeadConteiner : ItemConteiner
{
    public HeadConteiner(int count)
    {
        this.count = count;
    }
    [SerializeField] private int count;
    public override int GetContent()
    {
        return count;
    }

    public override Sprite GetIcon()
    {
        return StaticData.Instance.itemData.Head.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Head.Price;
    }
}