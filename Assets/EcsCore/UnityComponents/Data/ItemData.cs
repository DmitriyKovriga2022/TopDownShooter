using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public static ItemData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load("ItemData") as ItemData;
            }

            return instance;
        }
    }
    private static ItemData instance;

    public ItemBoxConfig[] Box;
    public ItemMedkitConfig[] Medkit;
    public ItemBagConfig[] Bag;
    public ItemBulletConfig[] Bullet;
    public ItemFoodConfig[] Food;
    public ItemArmorConfig[] Body;
    public ItemWeaponConfig[] Weapon;
    public ItemHeadConfig[] Head;
    public SoundClips sound;


    [System.Serializable]
    public class SoundClips
    {
        public AudioClip[] inspectItem;
        public AudioClip[] destroyItem;
    }

    [System.Serializable]
    public class ItemConfig
    {
        public string Name;
        public Sprite Sprite;
        public int Price;
    }

    [System.Serializable]
    public class ItemArmorConfig : ItemConfig
    {
        public int ArmorValue;
    }

    [System.Serializable]
    public class ItemFoodConfig : ItemConfig
    {
        public int Power;
    }

    [System.Serializable]
    public class ItemBulletConfig : ItemConfig
    {
    }

    [System.Serializable]
    public class ItemBagConfig : ItemConfig
    {
    }

    [System.Serializable]
    public class ItemMedkitConfig : ItemConfig
    {
        public int Power;
    }

    [System.Serializable]
    public class ItemBoxConfig : ItemConfig
    {
    }

    [System.Serializable]
    public class ItemWeaponConfig : ItemConfig
    {
        public WeaponSettingsData Settings;
    }

    [System.Serializable]
    public class ItemHeadConfig : ItemConfig
    {
    }
}
