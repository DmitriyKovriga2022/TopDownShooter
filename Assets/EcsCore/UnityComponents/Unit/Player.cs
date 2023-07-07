using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityComponent
{
    public class Player : MonoBehaviour, ILookTarget
    {
        public event Action<Vector2> EventLookAt;

        private Vector2 targetPosition;

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
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider is TilemapCollider2D)
            {
                Vector3Int position = Vector3Int.FloorToInt(collision.contacts[0].point);
                Tilemap tilemap = collision.collider.GetComponent<Tilemap>();
                Sprite sprite = tilemap.GetSprite(position);
                if (sprite == StaticData.Instance.spriteCollisionData.exitPointSprite)
                {
                    UIGame.Instance.ShowLeaveMenu();
                }
            }

            //if (collision.collider.TryGetComponent(out Item item))
            //{
            //    item.OnCollisionUnit(entity);
            //}
        }
    }

   
}