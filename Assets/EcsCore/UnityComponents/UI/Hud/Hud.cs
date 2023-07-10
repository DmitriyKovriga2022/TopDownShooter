using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public event Action EventShowDeadMenu;

    public UIBag UIInventaryBag => uiInventaryBag;
    [SerializeField] private UIBag uiInventaryBag;
    
    public UIBag UIBag => uiBag;
    [SerializeField] private UIBag uiBag;

    public HudWeapon HudWeapon => hudWeapon;
    [SerializeField] private HudWeapon hudWeapon;

    public HudHealth HudHealth => hudHealth;
    [SerializeField] private HudHealth hudHealth;

    public void ShowDeadPanel()
    {
        EventShowDeadMenu?.Invoke();
    }

}