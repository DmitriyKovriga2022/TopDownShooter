using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class HudWeapon : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    [SerializeField] private Text magazinText;

    public void ShowAmmo(int value)
    {
        ammoText.text = "Ammo " + value.ToString();
    }

    public void ShowMagazin(int value)
    {
        magazinText.text = "MaxAmmo " + value.ToString();
    }
}
