using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public HudWeapon HudWeapon => hudWeapon;
    [SerializeField] private HudWeapon hudWeapon;
}