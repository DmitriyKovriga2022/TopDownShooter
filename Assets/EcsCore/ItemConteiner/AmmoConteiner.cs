
using Leopotam.Ecs;
﻿using System;
using UnityEngine;

[Serializable]
public class AmmoConteiner : ItemConteiner
{
    public AmmoConteiner(int count, int configId)
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

    public void AddingContentValue(int value)
    {
        count += value;
    }
    
    public void SeContentValue(int value)
    {
        count = value;
    }

    public override Sprite GetIcon()
    {
       return ItemData.Instance.Bullet[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Bullet[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        Debug.Log("Apply Function In Progress");
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}
