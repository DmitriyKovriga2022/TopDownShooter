using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class FoodConteiner : ItemConteiner
{
    public FoodConteiner(int count)
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
        return StaticData.Instance.itemData.Food.Sprite;
    }

    public override int GetPrice()
    {
        return StaticData.Instance.itemData.Food.Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        entityTarget.Get<EcsComponent.ApplyFoodEvent>().Count = count;

    }

    public override void Drop(EcsEntity entityTarget)
    {
        throw new System.NotImplementedException();
    }
}
