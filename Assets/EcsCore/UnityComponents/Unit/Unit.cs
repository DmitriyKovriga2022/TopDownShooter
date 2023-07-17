using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityComponent
{
    public class Unit : MonoBehaviour
    {
        public EcsEntity selfEntity;
        public new Rigidbody2D rigidbody;
        public Transform mainTransform;
        public Transform visualTransform;
        public Transform weaponHolder;

        [SerializeField] private FactionHandler factionHandler;

        public void Initialise(EcsEntity entity)
        {
            this.selfEntity = entity;
            var hitHandler = gameObject.GetComponentInChildren<UnityComponent.HitHandler>();
            hitHandler.entity = this.selfEntity;
            factionHandler = new FactionHandler();
            factionHandler.SelfFactions = new FactionSelf(new Netral());
            factionHandler.Factions = new FactionRelationship[3] 
            { 
                new FactionRelationship(new Netral(), 50), 
                new FactionRelationship(new Military(), 50),
                new FactionRelationship(new Bandit(), 50),
            };
        }

        public void Dead()
        {
            Debug.Log("Dead: " + this);
            Destroy(gameObject);
        }

        public void DebugSetHealth()
        {
            selfEntity.Get<EcsComponent.HitBulletEvent>().hitPower = 10;
        }

        
    }
}
