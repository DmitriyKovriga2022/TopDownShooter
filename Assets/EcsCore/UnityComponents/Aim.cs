using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Aim : MonoBehaviour
{
    [SerializeField] private Image aimImage;

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
       transform.position = Input.mousePosition;
    }

    
}
