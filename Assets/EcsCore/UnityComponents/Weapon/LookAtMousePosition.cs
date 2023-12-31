using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMousePosition : MonoBehaviour
{
    private SpriteRenderer render;
    private Vector3 cursorPosition;

    private void Awake()
    {
        render = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Cursor.visible) return;

        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = cursorPosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (cursorPosition.x < transform.position.x)
        {
            render.flipY = true;
        }
        else
        {
            render.flipY = false;
        }
    }
}
