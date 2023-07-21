using Leopotam.Ecs;
﻿using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class HeadConteiner : ItemConteiner
{
    public HeadConteiner(int configId)
    {
        this.config = ItemData.Instance.Head[configId];
    }
    public HeadConteiner(ItemData.ItemHeadConfig config)
    {
        this.config = config;
    }

    private ItemData.ItemHeadConfig config;

    public override int GetCount()
    {
        return 1;
    }

    public override int GetWearout()
    {
        return 0;
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
        entityTarget.Get<EcsComponent.EquippingHeadIntent>();
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}