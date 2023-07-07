using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static UIGame instance;
    public static UIGame Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<UIGame>();
            }

            return instance;
        }
        

    }
    public event Action EventOnEscape;

    [SerializeField] private Hud hud;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private DeadMenu deadMenu;
    [SerializeField] private LeaveZoneMenu leaveMenu;
    [SerializeField] private Aim aim;
    [SerializeField] private Button showMenuButton;

    private void Start()
    {
        hud.EventShowDeadMenu += Hud_EventShowDeadMenu;

        showMenuButton.onClick.AddListener(OnButtonShowMenu);
        pauseMenu.EventOnButtonExit += PauseMenu_EventOnButtonExit;
        pauseMenu.Hide();

        deadMenu.EventOnButtonExit += DeadMenu_EventOnButtonExit;
        deadMenu.Hide();

        leaveMenu.EventOnButtonExit += LeaveMenu_EventOnButtonExit;
        leaveMenu.Hide();

        aim.Show();
        Cursor.visible = false;
    }

    private void Hud_EventShowDeadMenu()
    {
        ShowDeadMenu();
    }

    private void DeadMenu_EventOnButtonExit()
    {
        deadMenu.EventOnButtonExit -= DeadMenu_EventOnButtonExit;
        QuitApplication();
    }
    
    private void LeaveMenu_EventOnButtonExit()
    {
        leaveMenu.EventOnButtonExit -= LeaveMenu_EventOnButtonExit;
        QuitApplication();
    }

    private void PauseMenu_EventOnButtonExit()
    {
        pauseMenu.EventOnButtonExit -= PauseMenu_EventOnButtonExit;
        QuitApplication();
    }

    private void Update()
    {
        if (deadMenu.gameObject.activeSelf) return;
        if (leaveMenu.gameObject.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                HidePauseMenu();
            }
            else
            {
                ShowPauseMenu();
            }
        }
    }

    private void OnButtonShowMenu()
    {
        ShowPauseMenu();
    }

    private void ShowDeadMenu()
    {
        pauseMenu.Hide();
        leaveMenu.Hide();
        aim.Hide();
        Cursor.visible = true;
        deadMenu.Show();
    }

    public void ShowLeaveMenu()
    {
        pauseMenu.Hide();
        aim.Hide();
        Cursor.visible = true;
        leaveMenu.EventOnHideMenu += LeaveMenu_EventOnHideMenu;
        leaveMenu.Show();
    }

    private void ShowPauseMenu()
    {
        //Debug.Log("Show Menu");
        aim.Hide();
        pauseMenu.Show();
        Cursor.visible = true;
        pauseMenu.EventOnHideMenu += PauseMenu_EventOnHideMenu;
    }

    private void HideLaeveMenu()
    {
        //Debug.Log("Hide Menu");
        leaveMenu.Hide();
        aim.Show();
        Cursor.visible = false;
    }

    private void HidePauseMenu()
    {
        //Debug.Log("Hide Menu");
        pauseMenu.Hide();
        aim.Show();
        Cursor.visible = false;
    }

    private void LeaveMenu_EventOnHideMenu()
    {
        HideLaeveMenu();
        leaveMenu.EventOnHideMenu -= LeaveMenu_EventOnHideMenu;
    }

    private void PauseMenu_EventOnHideMenu()
    {
        HidePauseMenu();
        pauseMenu.EventOnHideMenu -= PauseMenu_EventOnHideMenu;
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

        if (leaveMenu != null)
        {
            leaveMenu.EventOnButtonExit -= LeaveMenu_EventOnButtonExit;
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
