using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class MedKitConteiner : ItemConteiner
{
    public MedKitConteiner(int configId)
    {
        this.configId = configId;
    }

    private int configId;

    public override int GetCount()
    {
        return 1;
    }

    public override int GetWearout()
    {
        return 0;
    }

    public override int GetConfigId()
    {
        return configId;
    }

    public override Sprite GetIcon()
    {
        return ItemData.Instance.Medkit[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Medkit[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        entityTarget.Get<EcsComponent.ApplyMedKitEvent>().Power = ItemData.Instance.Medkit[configId].Power;
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
