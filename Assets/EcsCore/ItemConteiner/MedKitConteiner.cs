using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class MedKitConteiner : ItemConteiner
{
    public MedKitConteiner(int count)
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
        return StaticData.Instance.itemData.Medkit.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Medkit.Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        entityTarget.Get<EcsComponent.ApplyMedKitEvent>().Count = count;
    }

    public override void Drop(EcsEntity entityTarget)
    {
        throw new System.NotImplementedException();
    }
}
