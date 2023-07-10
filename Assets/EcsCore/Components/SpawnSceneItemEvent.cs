using System.Collections;
using UnityEngine;

namespace EcsComponent
{
    public struct SpawnSceneItemEvent
    {
        public Vector3 position;
        public ItemConteiner[] conteiners;
    }
}