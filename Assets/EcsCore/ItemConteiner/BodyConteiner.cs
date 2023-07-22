
﻿using Leopotam.Ecs;
﻿using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class BodyConteiner: ItemConteiner
{
    public BodyConteiner(int configId, int wearout)
    {
        this.configId = configId;
        this.wearout = wearout;
    }

    private int configId;
    private int wearout;

    public override int GetCount()
    {
        return 1;
    }

    public override int GetWearout()
    {
        return wearout;
    }

    public override int GetConfigId()
    {
        return configId;
    }

    public override Sprite GetIcon()
    {
        return ItemData.Instance.Body[configId].Sprite;
    }

    public override int GetPrice()
    {
        return ItemData.Instance.Body[configId].Price;
    }

    public override void Apply(EcsEntity entityTarget)
    {
        ref var body = ref entityTarget.Get<EcsComponent.EquippingBodyIntent>();
        body.configIndex = configId;
        body.wearout = wearout;
    }

    public override void Drop(EcsEntity entityTarget)
    {
        Debug.Log("Drop Function In Progress");
    }
}