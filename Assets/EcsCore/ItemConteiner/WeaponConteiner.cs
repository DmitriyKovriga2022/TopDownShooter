using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class WeaponConteiner : ItemConteiner
{
    public WeaponConteiner(int configId, int wearout)
    {
        this.config = ItemData.Instance.Weapon[configId];
        this.wearout = wearout;
    }

    public WeaponConteiner(ItemData.ItemWeaponConfig config, int wearout)
    {
        this.config = config;
        this.wearout = wearout;
    }

    private ItemData.ItemWeaponConfig config;
    public int Wearout => wearout;
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
        entityTarget.Get<EcsComponent.EquippingWeaponIntent>();
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
