using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class FoodConteiner : ItemConteiner
{
    public FoodConteiner(int count, int configId)
    {
        this.count = count;
        this.configId = configId;
    }

    private int count;
    private int configId;

    public override int GetCount()
    {
        return count;
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
        return ItemData.Instance.Food[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Food[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        entityTarget.Get<EcsComponent.ApplyFoodEvent>().Power = ItemData.Instance.Food[configId].Power;

    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
