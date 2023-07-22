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

    public HudArmor HudArmor => hudArmor;
    [SerializeField] private HudArmor hudArmor;

    public void Initialise()
    {
        inventory = Instantiate(StaticData.Instance.inventoryPrefab, transform);
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