using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class HudWeapon : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    [SerializeField] private Text magazinText;

    public void ShowMagazine(int value)
    {
        ammoText.text = "Magazine " + value.ToString();
    }

    public void ShowTotalAmmo(int value)
    {
        magazinText.text = "Ammo " + value.ToString();
    }
}
