using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityComponent
{
    public class Player : MonoBehaviour, ILookTarget
    {
        public event Action<Vector2> EventLookAt;
        public EcsEntity entity;
        private Vector2 targetPosition;
        private LookAtInteractionObject interactionObject;

        public void Awake()
        {
            interactionObject = new LookAtInteractionObject();
        }

        private void Update()
        {
            if (!Cursor.visible)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                targetPosition = transform.right;
            }

            EventLookAt?.Invoke(targetPosition);

            if(Input.GetKeyDown(KeyCode.Delete))
            {
                GetComponent<Unit>().DebugSetHealth();
            }
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                interactionObject.ToInteract(entity);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                entity.Get<EcsComponent.ShowUIBagEvent>().entity = entity;
                entity.Get<EcsComponent.ShowUIEquipEvent>().entity = entity;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //if (collision.collider is TilemapCollider2D)
            //{
            //    Vector3Int position = Vector3Int.FloorToInt(collision.contacts[0].point);
            //    Tilemap tilemap = collision.collider.GetComponent<Tilemap>();
            //    Sprite sprite = tilemap.GetSprite(position);
            //    if (sprite == StaticData.Instance.spriteCollisionData.exitPointSprite)
            //    {
            //        UIGame.Instance.ShowLeaveMenu();
            //    }
            //}
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out InteractionObject interactionObject))
            {
                this.interactionObject.InteractObject = interactionObject;
            }

            if (collider.TryGetComponent(out ExitPoint point))
            {
                UIGame.Instance.ShowLeaveMenu();
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out SceneItem item))
            {
                if (this.interactionObject.InteractObject == item)
                {
                    this.interactionObject.InteractObject = null;
                }
            }

            if (collider.TryGetComponent(out InteractionObject interactionObject))
            {
                if (this.interactionObject.InteractObject == interactionObject)
                {
                    this.interactionObject.InteractObject = null;
                }
            }
        }

    }

    [System.Serializable]
    public class LookAtInteractionObject
    {
        public InteractionObject InteractObject
        {
            get
            {
                return currentObject;
            }
            set
            {
                if (currentObject != null)
                {
                    currentObject.HideInfo();
                }

                currentObject = value;

                if(currentObject != null)
                {
                    currentObject.ShowInfo();
                }
            }
        }
        private InteractionObject currentObject;

        public void ToInteract(EcsEntity other)
        {
            if(currentObject != null)
            {
                currentObject.ToInteract(other);
            }
        }
    }


}