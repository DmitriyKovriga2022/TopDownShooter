using System.Collections;
using UnityEngine;

[System.Serializable]
public class FactionRelationship
{
    public FactionRelationship(Faction faction, int Relationship)
    {
        this.faction = faction;
        this.Relationship = Relationship;
        Name = faction.ToString();
    }

    public string Name;
    public int Relationship = 0;
    public Faction faction;
}