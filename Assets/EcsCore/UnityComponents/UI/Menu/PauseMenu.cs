using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : BaseMenu
{
    public event Action EventOnHideMenu;

    [SerializeField] private Button returnButton;
    [SerializeField] private Button preferenceButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        returnButton.onClick.AddListener(OnButtonReturn);
        preferenceButton.onClick.AddListener(OnButtonPreference);
        exitButton.onClick.AddListener(OnButtonExit);
    }

    private void OnButtonExit()
    {
        Debug.Log("OnButtonExit");
        Application.Quit();
    }

    private void OnButtonPreference()
    {
        Debug.Log("OnButtonPreference");
    }

    private void OnButtonReturn()
    {
        EventOnHideMenu?.Invoke();
    }
}
