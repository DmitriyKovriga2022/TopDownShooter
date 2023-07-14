using System.Collections;
using UnityEngine;

namespace EcsComponent
{
    public struct SpawnUnitEvent
    {
        public Vector3 position;
        public UnitType unitType;
    }
}