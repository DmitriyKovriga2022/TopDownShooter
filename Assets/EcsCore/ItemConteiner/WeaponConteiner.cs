using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class WeaponConteiner : ItemConteiner
{
    public WeaponConteiner(int configId)
    {
        this.config = ItemData.Instance.Weapon[configId];
    }

    public WeaponConteiner(ItemData.ItemWeaponConfig config)
    {
        this.config = config;
    }

    private ItemData.ItemWeaponConfig config;

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
        entityTarget.Get<EcsComponent.EquippingWeaponIntent>();
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
