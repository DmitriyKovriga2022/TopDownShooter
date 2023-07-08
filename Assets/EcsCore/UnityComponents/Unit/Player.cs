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
        private LookAtItem lookAtItem;

        public void Awake()
        {
            lookAtItem = new LookAtItem();
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
               lookAtItem.PickUp(entity);
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
            if (collider.TryGetComponent(out SceneItem item))
            {
                // item.ShowInfo();
                lookAtItem.Item = item;
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
                // item.HideInfo();
                lookAtItem.Item = null;
            }
        }

    }

    [System.Serializable]
    public class LookAtItem
    {
        public SceneItem Item
        {
            set
            {
                if (item != null)
                {
                    item.HideInfo();
                }

                item = value;

                if(item != null)
                {
                    item.ShowInfo();
                }
            }
        }
        private SceneItem item;

        public void PickUp(EcsEntity other)
        {
            if(item != null)
            {
                item.PickUp(other);
            }
        }
    }
}