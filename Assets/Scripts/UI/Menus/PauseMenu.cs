using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    public Button resumeButton;
    public Button settingsButton;
    public Button restartButton;
    [SerializeField]
    private InGameMenu _inGameMenu;


    protected override void OnInitialize()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        _inGameMenu.pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    private void OnPauseButtonClicked() 
    {
        Time.timeScale = 0;
        Show();
    }

    private void OnRestartButtonClicked()
    {
        throw new NotImplementedException();
    }

    private void OnSettingsButtonClicked()
    {
        //menuManager.Show<SettingsMenu>();
    }

    private void OnResumeButtonClicked()
    {
        Time.timeScale = 1;
        Hide();
        //menuManager.Hide<PauseMenu>();
    }
}
