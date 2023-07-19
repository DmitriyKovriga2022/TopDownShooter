using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class MedKitConteiner : ItemConteiner
{
    public MedKitConteiner(int configId)
    {
        this.config = ItemData.Instance.Medkit[configId];
    }

    public MedKitConteiner(ItemData.ItemMedkitConfig config)
    {
        this.config = config;
    }

    private ItemData.ItemMedkitConfig config;

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
        entityTarget.Get<EcsComponent.ApplyMedKitEvent>().Power = config.Power;
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
