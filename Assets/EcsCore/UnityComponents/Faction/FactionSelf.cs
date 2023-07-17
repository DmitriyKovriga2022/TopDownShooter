using System.Collections;
using UnityEngine;

[System.Serializable]
public class FactionSelf
{
    public FactionSelf(Faction faction)
    {
        this.faction = faction;
        Name = faction.ToString();
    }
    public string Name;
    public Faction faction;
}