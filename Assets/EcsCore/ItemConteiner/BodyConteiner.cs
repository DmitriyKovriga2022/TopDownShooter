using Leopotam.Ecs;
using UnityEngine;

public class BodyConteiner: ItemConteiner
{
    public BodyConteiner(int configId)
    {
        this.config = ItemData.Instance.Body[configId];
    }

    public BodyConteiner(ItemData.ItemArmorConfig config)
    {
        this.config = config;
    }

    private ItemData.ItemArmorConfig config;

    public override int GetCount()
    {
        return 1;
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