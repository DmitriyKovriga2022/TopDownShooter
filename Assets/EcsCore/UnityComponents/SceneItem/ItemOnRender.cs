using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnRender : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Debug.Log("Item Invisible");
    }
    void OnBecameVisible()
    {
        Debug.Log("Item Visible");
    }
}
