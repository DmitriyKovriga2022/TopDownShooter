using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudArmor : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void ShowArmor(int value, int maxValue)
    {
        slider.value = value;
        slider.maxValue = maxValue;
    }
}
