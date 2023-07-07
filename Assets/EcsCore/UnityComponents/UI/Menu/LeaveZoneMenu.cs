using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveZoneMenu : BaseMenu
{
    public event Action EventOnButtonExit;
    public event Action EventOnHideMenu;

    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private void Start()
    {
        yesButton.onClick.AddListener(OnButtonYas);
        noButton.onClick.AddListener(OnButtonNo);
    }

    private void OnButtonNo()
    {
        EventOnHideMenu?.Invoke();
    }

    private void OnButtonYas()
    {
        EventOnButtonExit?.Invoke();
    }
}
