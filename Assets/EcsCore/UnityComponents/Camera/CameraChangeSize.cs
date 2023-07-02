using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeSize : MonoBehaviour
{
    [SerializeField] private float minSize = 1;
    [SerializeField] private float maxSize = 16;
    [SerializeField] private new Camera camera;

    private float size;

    private void Start()
    {
        size = camera.orthographicSize;
    }

    private void Update()
    {
        size += Input.GetAxis("Mouse ScrollWheel");
        size = Mathf.Clamp(size, minSize, maxSize);
        camera.orthographicSize = size;
    }

}
