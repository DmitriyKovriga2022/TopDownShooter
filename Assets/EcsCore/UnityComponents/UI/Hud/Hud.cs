using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private UIGame uiGame;

    public HudWeapon HudWeapon => hudWeapon;
    [SerializeField] private HudWeapon hudWeapon;

    public HudHealth HudHealth => hudHealth;
    [SerializeField] private HudHealth hudHealth;

    public void ShowDeadPanel()
    {
        uiGame.ShowDeadMenu();
    }

}