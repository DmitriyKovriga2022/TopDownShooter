using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTime : MonoBehaviour
{
    [SerializeField] private float liveTime;

    private void OnEnable()
    {
        Invoke(nameof(SelfDestroy), liveTime);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
