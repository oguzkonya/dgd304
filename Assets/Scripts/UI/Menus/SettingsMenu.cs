using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField]
    private PauseMenu _pauseMenu;
    public Button closeButton;

    protected override void OnInitialize()
    {
        closeButton.onClick.AddListener(OnCloseButtonClicked);
        _pauseMenu.settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }

    private void OnSettingsButtonClicked() 
    {
        Show();
    }

    private void OnCloseButtonClicked()
    {
        Hide();
        //menuManager.Hide<SettingsMenu>();
    }
}
