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
        private Canvas canvas;
        private new SpriteRenderer renderer;

        private void Awake()
        {
            renderer = GetComponentInChildren<SpriteRenderer>(true);
            canvas = GetComponentInChildren<Canvas>(true);
            canvas.gameObject.SetActive(false);
        }

        public void SetSprite(Sprite sprite)
        {
            renderer.sprite = sprite;
        }

        public void ShowInfo()
        {
            canvas.gameObject.SetActive(true);
        }

        public void HideInfo()
        {
            canvas.gameObject.SetActive(false);
        }

        public void PickUp(EcsEntity other)
        {
            ref var component = ref entity.Get<EcsComponent.PickUpSceneItemEvent>();
            component.otherEntity = other;
            //component.worldPosition = transform.position;
            //ref var conteiners = ref entity.Get<EcsComponent.Bag>().conteiners;
            //component.conteiners = conteiners;
        }

        public void DestroySelf()
        {
            Debug.Log("DestroySelf:" + this);
            Destroy(gameObject);
        }
    }
}
