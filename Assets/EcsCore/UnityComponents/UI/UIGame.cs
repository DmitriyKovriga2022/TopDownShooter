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
    [SerializeField] private DeadMenu deadMenu;
    [SerializeField] private Aim aim;
    [SerializeField] private Button showMenuButton;

    private void Start()
    {
        showMenuButton.onClick.AddListener(OnButtonShowMenu);
        pauseMenu.EventOnButtonExit += PauseMenu_EventOnButtonExit;
        pauseMenu.Hide();

        deadMenu.EventOnButtonExit += DeadMenu_EventOnButtonExit;
        deadMenu.Hide();

        aim.Show();
        Cursor.visible = false;
    }

    private void DeadMenu_EventOnButtonExit()
    {
        deadMenu.EventOnButtonExit -= DeadMenu_EventOnButtonExit;
        QuitApplication();
    }

    private void PauseMenu_EventOnButtonExit()
    {
        pauseMenu.EventOnButtonExit -= PauseMenu_EventOnButtonExit;
        QuitApplication();
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

    public void ShowDeadMenu()
    {
        pauseMenu.Hide();
        aim.Hide();
        Cursor.visible = true;
        deadMenu.Show();

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

    private void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#elif UNITY_IOS
         Application.Quit();
#else
         Application.Quit();
#endif
    }

    private void OnDestroy()
    {
        if(pauseMenu != null)
        {
            pauseMenu.EventOnHideMenu -= PauseMenu_EventOnHideMenu;
            pauseMenu.EventOnButtonExit -= PauseMenu_EventOnButtonExit;
        }

        if (deadMenu != null)
        {
            deadMenu.EventOnButtonExit -= DeadMenu_EventOnButtonExit;
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
