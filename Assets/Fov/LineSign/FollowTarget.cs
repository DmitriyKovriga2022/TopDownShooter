using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;

    public Transform Target
    {
        set
        {
            target = value;

            if(target != null)
            {
                fieldOfView.enabled = true;
            }
            else
            {
                fieldOfView.enabled = false;
            }

        }
    }
    private Transform target;

    private void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position;
    }
}
