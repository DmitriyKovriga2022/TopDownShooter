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

        public void Initialise(EcsEntity entity)
        {
            this.entity = entity;
            var hitHandler = gameObject.GetComponentInChildren<UnityComponent.HitHandler>();
            hitHandler.entity = this.entity;
        }

        public void Dead()
        {
            Debug.Log("Dead: " + this);
            Destroy(gameObject);
        }

        public void DebugSetHealth()
        {
            entity.Get<EcsComponent.HitBulletEvent>().hitPower = 10;
        }

        
    }
}
