using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class WeaponConteiner : ItemConteiner
{
    public WeaponConteiner(int configId, int wearout)
    {
        this.configId = configId;
        this.wearout = wearout;
    }


    private int configId;
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

    public override int GetConfigId()
    {
        return configId;
    }

    public override Sprite GetIcon()
    {
        return ItemData.Instance.Weapon[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Weapon[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        ref var weapon = ref entityTarget.Get<EcsComponent.EquippingWeaponIntent>();
        weapon.configIndex = configId;
        
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }

   
}
