using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemConteiner
{
    public abstract int GetContent();
    public abstract Sprite GetIcon();
}
