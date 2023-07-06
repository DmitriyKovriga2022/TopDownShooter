using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponent
{
    public class Unit : MonoBehaviour
    {
        public EcsEntity entity;
        public new Rigidbody2D rigidbody;
        public Transform mainTransform;
        public Transform visualTransform;
        public Transform weaponHolder;

        [SerializeField] private Bag bag;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Item item))
            {
                item.OnCollisionUnit(entity);
            }
        }
    }
}
