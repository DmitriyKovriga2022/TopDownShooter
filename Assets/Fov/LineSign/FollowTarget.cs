using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    public Transform Target
    {
        set
        {
            target = value;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position;
    }
}
