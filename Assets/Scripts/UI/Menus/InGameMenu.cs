using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : Menu
{
    public Button pauseButton;

    protected override void OnInitialize()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = 0;
        menuManager.Show<PauseMenu>();
    }

    // TODO: Show air
}
