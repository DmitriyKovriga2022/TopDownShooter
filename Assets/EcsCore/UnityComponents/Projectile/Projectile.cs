using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponent
{
    public class Projectile : MonoBehaviour, IGameObject
    {
        [SerializeField] private GameObject hitPrefab;
        public Transform Transform => transform;
        [SerializeField] new Transform transform;
        public float Speed => speed;
        [SerializeField] private float speed;

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
