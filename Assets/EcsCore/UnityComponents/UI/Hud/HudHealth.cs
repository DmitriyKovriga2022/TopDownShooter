using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void ShowHealth(int value, int maxValue)
    {
        slider.value = value;
        slider.maxValue = maxValue;
    }
}
