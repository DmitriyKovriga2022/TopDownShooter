﻿using System.Collections;
using UnityEngine;

namespace UnityComponent
{
    public class LookAtTargetPosition : MonoBehaviour
    {
        private SpriteRenderer render;
        private Vector3 targetPosition;

        public void LookAtTarget(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        private void Awake()
        {
            render = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (Cursor.visible) return;

            Vector3 dir = targetPosition - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (targetPosition.x < transform.position.x)
            {
                render.flipY = true;
            }
            else
            {
                render.flipY = false;
            }
        }
    }
}