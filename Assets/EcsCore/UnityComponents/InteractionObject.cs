using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public event Action<EcsEntity> EventToInteract;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        canvas.gameObject.SetActive(false);
    }

    public void ShowInfo()
    {
        canvas.gameObject.SetActive(true);
    }

    public void HideInfo()
    {
        canvas.gameObject.SetActive(false);
    }

    public void ToInteract(EcsEntity other)
    {
        EventToInteract?.Invoke(other);
    }

}