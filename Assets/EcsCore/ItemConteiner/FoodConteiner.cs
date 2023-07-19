using Leopotam.Ecs;
using UnityEngine;

[System.Serializable]
public class FoodConteiner : ItemConteiner
{
    public FoodConteiner(int count, int configId)
    {
        this.count = count;
        this.config = ItemData.Instance.Food[configId];
    }
    public FoodConteiner(int count, ItemData.ItemFoodConfig config)
    {
        this.count = count;
        this.config = config;
    }

    private int count;
    private ItemData.ItemFoodConfig config;

    public override int GetCount()
    {
        return count;
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
        entityTarget.Get<EcsComponent.ApplyFoodEvent>().Power = config.Power;

    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
