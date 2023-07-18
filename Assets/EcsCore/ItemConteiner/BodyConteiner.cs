using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class BodyConteiner: ItemConteiner
{
    public BodyConteiner(int count)
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
        return StaticData.Instance.itemData.Jacket.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Jacket.Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        entityTarget.Get<EcsComponent.EquippingBodyIntent>();
    }

    public override void Drop(EcsEntity entityTarget)
    {
        throw new System.NotImplementedException();
    }
}