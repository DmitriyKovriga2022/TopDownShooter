using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public HudWeapon hudWeapon;

    public void OnButtonQuit()
    {
        Application.Quit();
    }

}