using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class AmmoConteiner : ItemConteiner
{
    public AmmoConteiner(int count, int configId)
    {
        this.count = count;
        this.config = ItemData.Instance.Bullet[configId];
    }
    public AmmoConteiner(int count, ItemData.ItemBulletConfig config)
    {
        this.count = count;
        this.config = config;
    }

    private int count;
    private ItemData.ItemBulletConfig config;

    public override int GetCount()
    {
        return count;
    }

    public override int GetWearout()
    {
        return 0;
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
       return config.Sprite;
    }

    public override int GetPrice()
    {
        return config.Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        Debug.Log("Apply Function In Progress");
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
