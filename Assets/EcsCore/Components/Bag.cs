using System;
using System.Collections;
using UnityEngine;

namespace EcsComponent
{
    [Serializable]
    public struct Bag
    {
        public int configIndex;
        public ItemConteiner[] conteiners;

    }
}