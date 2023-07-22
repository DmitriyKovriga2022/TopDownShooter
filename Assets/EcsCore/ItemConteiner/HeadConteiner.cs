using Leopotam.Ecs;
﻿using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class HeadConteiner : ItemConteiner
{
    public HeadConteiner(int configId)
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
        return ItemData.Instance.Head[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Head[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        ref var head = ref entityTarget.Get<EcsComponent.EquippingHeadIntent>();
        head.configIndex = configId;
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}