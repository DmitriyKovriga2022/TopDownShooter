using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMarkerHandler : MonoBehaviour
{
    public static UIMarkerHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UIMarkerHandler>();
            }

            return instance;
        }
    }
    private static UIMarkerHandler instance;

    [SerializeField] private UIMarker uiMarkerPrefab;
    [SerializeField] private List<UIMarker> markers = new List<UIMarker>();

    public void AddMarker(Marker marker)
    {
        var uiMarker = Instantiate(uiMarkerPrefab, transform);
        uiMarker.target = marker;
        markers.Add(uiMarker);
    }

    private void LateUpdate()
    {
        for (int i = 0; i < markers.Count; i++)
        {
            if(markers[i].target == null)
            {
                Destroy(markers[i].gameObject);
                markers.RemoveAt(i);
                continue;
            }

            Vector2 position = Camera.main.WorldToScreenPoint(markers[i].target.transform.position);

            RectTransform transform = markers[i].transform as RectTransform;
            transform.position = position;
        }
        
    }

}
