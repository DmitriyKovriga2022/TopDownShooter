using System.Collections;
using UnityEngine;

namespace UnityComponent
{
    public class LookAtPosition : MonoBehaviour
    {
        private SpriteRenderer render;
        private ILookTarget lookTarget;

        private void Awake()
        {
            render = GetComponentInChildren<SpriteRenderer>();
            lookTarget = GetComponentInParent<ILookTarget>();
            lookTarget.EventLookAt += LookTarget_EventLookAt;
        }

        private void LookTarget_EventLookAt(Vector2 targetPosition)
        {
            Vector3 dir = (Vector3)targetPosition - transform.position;
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

        private void OnDestroy()
        {
            lookTarget.EventLookAt -= LookTarget_EventLookAt;
        }
    }
}