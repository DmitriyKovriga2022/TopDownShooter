using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponent
{
    public class SceneItem : SceneObject, IGameObject
    {
        public EcsEntity entity;
        private new SpriteRenderer renderer;
        private InteractionObject interactionObject;

        private void Awake()
        {
            renderer = GetComponentInChildren<SpriteRenderer>(true);
            interactionObject = Instantiate(StaticData.Instance.interactionObjectPrefab, transform);
            interactionObject.EventToInteract += InteractionObject_EventToInteract;
        }

        private void InteractionObject_EventToInteract(EcsEntity other)
        {
            ref var component = ref entity.Get<EcsComponent.PickUpSceneItemEvent>();
            component.otherEntity = other;
            //component.worldPosition = transform.position;
            //ref var conteiners = ref entity.Get<EcsComponent.Bag>().conteiners;
            //component.conteiners = conteiners;
        }

        public void SetSprite(Sprite sprite)
        {
            renderer.sprite = sprite;
        }

        public void DestroySelf()
        {
            Debug.Log("DestroySelf:" + this);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (interactionObject != null)
            {
                interactionObject.EventToInteract -= InteractionObject_EventToInteract;
            }
        }

    }
}
