using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    Vector2 cursorPosition;

    void Update()
    {
        cursorPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                            transform.eulerAngles.y,
                                            cursorPosition.y * 180);

        //if (cursorPosition.y < transform.position.y)
        //{
        //    transform.eulerAngles = Vector3.right * 180;
        //}
        //else
        //{
        //   transform.eulerAngles = Vector3.zero;
        //}
    }
}
