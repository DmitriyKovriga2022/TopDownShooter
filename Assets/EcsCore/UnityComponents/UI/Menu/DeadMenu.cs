using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : BaseMenu
{
    public event Action EventOnButtonExit;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(OnButtonRestart);
        exitButton.onClick.AddListener(OnButtonExit);
    }

    private void OnButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnButtonExit()
    {
        EventOnButtonExit?.Invoke();
    }

}
