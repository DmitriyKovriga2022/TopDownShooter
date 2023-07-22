using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsComponent
{
    /// <summary>
    /// Текущая экипировка
    /// </summary>
    public struct EquipBody : IEquiping
    {
        public int configIndex;
        public int wearout;
    }
}