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
            ref var conteiner = ref entity.Get<EcsComponent.SceneItem>().conteiner;
            ref var component = ref entity.Get<EcsComponent.PickUpSceneItemEvent>();
            component.otherEntity = other;
            component.worldPosition = transform.position;

            if(conteiner is AmmoConteiner)
            {
                component.conteiner = new AmmoConteiner((conteiner as AmmoConteiner).GetContent());
            }

            if (conteiner is MedKitConteiner)
            {
                component.conteiner = new MedKitConteiner((conteiner as MedKitConteiner).GetContent());
            }


        }

        public void DestroySelf()
        {
            Debug.Log("DestroySelf:" + this);
            Destroy(gameObject);
        }
    }
}
