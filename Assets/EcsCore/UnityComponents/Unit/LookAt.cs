using System;
using System.Collections;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public event Action<Vector2> EventLookAt;

    public void LookTarget(Vector3 position)
    {
        EventLookAt?.Invoke(position);

    }
}