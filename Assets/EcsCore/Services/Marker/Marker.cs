using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    private void Start()
    {
        UIMarkerHandler.Instance.AddMarker(this);
    }
}
