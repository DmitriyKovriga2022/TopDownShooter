using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemConteiner
{
    public abstract int GetContent();
}

[System.Serializable]
public class AmmoConteiner : ItemConteiner
{
    public AmmoConteiner(int count)
    {
        this.count = count;
    }
    private int count;
    public override int GetContent()
    {
        return count;
    }
}

[System.Serializable]
public class MedKitConteiner : ItemConteiner
{
    public MedKitConteiner(int count)
    {
        this.count = count;
    }
    private int count;
    public override int GetContent()
    {
        return count;
    }
}
