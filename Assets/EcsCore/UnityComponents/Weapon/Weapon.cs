using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponent
{
    public class Weapon : MonoBehaviour
    {
        public Transform PointShoot => pointShoot;
        [SerializeField] private Transform pointShoot;

        public Transform RenderTransform => renderTransform;
        [SerializeField] private Transform renderTransform;

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

    }
}
