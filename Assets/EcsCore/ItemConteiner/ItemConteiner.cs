using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemConteiner
{
    public abstract int GetCount();
    public abstract Sprite GetIcon();
    public abstract int GetPrice();
    public abstract void Apply(EcsEntity entityTarget);
    public abstract void Drop(EcsEntity entityTarget);

}
