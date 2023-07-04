using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action EventOnEscape;

    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Aim aim;
    [SerializeField] private Button showMenuButton;

    private void Start()
    {
        showMenuButton.onClick.AddListener(OnButtonShowMenu);
        pauseMenu.Hide();
        aim.Show();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    public void OnButtonShowMenu()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        //Debug.Log("Show Menu");
        aim.Hide();
        pauseMenu.Show();
        Cursor.visible = true;
        pauseMenu.EventOnHideMenu += PauseMenu_EventOnHideMenu;
    }

    private void PauseMenu_EventOnHideMenu()
    {
        HideMenu();
        pauseMenu.EventOnHideMenu -= PauseMenu_EventOnHideMenu;
    }

    private void HideMenu()
    {
        //Debug.Log("Hide Menu");
        pauseMenu.Hide();
        aim.Show();
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        if(pauseMenu != null)
        {
            pauseMenu.EventOnHideMenu -= PauseMenu_EventOnHideMenu;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        aim.Hide();
        Cursor.visible = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        aim.Show();
        Cursor.visible = false;
    }
}
