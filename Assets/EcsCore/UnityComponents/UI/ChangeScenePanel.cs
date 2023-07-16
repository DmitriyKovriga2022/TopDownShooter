using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenePanel : MonoBehaviour
{
    [SerializeField] private Button toBaseButton;
    [SerializeField] private Button toRaidButton;

    private void Start()
    {
        toBaseButton.onClick.AddListener(OnButtonToBase);
        toRaidButton.onClick.AddListener(OnButtonToRaid);
    }

    private void OnButtonToRaid()
    {
        SceneManager.LoadScene("Raid");
    }

    private void OnButtonToBase()
    {
        SceneManager.LoadScene("Base");
    }
}
