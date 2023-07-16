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
            public Conteiner(string name, float count)
            {
                this.name = name;
                this.count = count;
            }

            public string name;
            public float count;
        }

    }
}