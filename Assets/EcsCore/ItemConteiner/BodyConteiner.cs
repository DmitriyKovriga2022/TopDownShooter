using Leopotam.Ecs;
using UnityEngine;

public class BodyConteiner : ItemConteiner
{
    public BodyConteiner(int configId, int wearout)
    {
        this.config = ItemData.Instance.Body[configId];
        this.wearout = wearout;
    }

    public BodyConteiner(ItemData.ItemArmorConfig config, int wearout)
    {
        this.config = config;
        this.wearout = wearout;
    }

    private ItemData.ItemArmorConfig config;
    private int wearout;

    public override int GetCount()
    {
        return 1;
    }

    public override int GetWearout()
    {
        return wearout;
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
        entityTarget.Get<EcsComponent.EquippingBodyIntent>();
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}