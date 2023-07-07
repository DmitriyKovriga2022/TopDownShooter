using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityComponent
{
    public class Unit : MonoBehaviour
    {
        public EcsEntity entity;
        public new Rigidbody2D rigidbody;
        public Transform mainTransform;
        public Transform visualTransform;
        public Transform weaponHolder;

        private SpriteCollisionData spriteCollisionData;

        [SerializeField] private Bag bag;

        public void Initialise(SpriteCollisionData spriteCollisionData)
        {
            this.spriteCollisionData = spriteCollisionData;
        }

        public void Dead()
        {
            Debug.Log("Dead: " + this);
            Destroy(gameObject);
        }

    }
}
