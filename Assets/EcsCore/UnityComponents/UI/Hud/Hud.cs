using System;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public event Action EventShowDeadMenu;

    public UIInventoryPanel Inventory => inventory;
    [SerializeField] private UIInventoryPanel inventory;

    public HudWeapon HudWeapon => hudWeapon;
    [SerializeField] private HudWeapon hudWeapon;

    public HudHealth HudHealth => hudHealth;
    [SerializeField] private HudHealth hudHealth;

    public void Initialise()
    {
        inventory.Initialise();
    }

    public void ShowDeadPanel()
    {
        EventShowDeadMenu?.Invoke();
    }

    public bool InventoryIsEnable
    {
        get
        {
            if (inventory.isActiveAndEnabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}