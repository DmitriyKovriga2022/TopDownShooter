using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private int item; 

    public void AddItem()
    {
        item++;
    }

}
