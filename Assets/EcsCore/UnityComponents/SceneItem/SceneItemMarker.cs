using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace UnityComponent
{
    public class SceneItemMarker : MonoBehaviour
    {
        public Conteiner[] items;

        public void DestroySelf()
        {
            Destroy(gameObject);
        }


        [System.Serializable]
        public class Conteiner
        {
            public string name;
            public float count;
        }

    }
}