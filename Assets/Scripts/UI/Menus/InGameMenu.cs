using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : Menu, IAnyAirListener
{
    public Button pauseButton;
    public TextMeshProUGUI airText;

    public void OnAnyAir(GameEntity entity, float value)
    {
        airText.text = value.ToString("0.00");
    }

    protected override void OnInitialize()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddAnyAirListener(this);
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = 0;
        menuManager.Show<PauseMenu>();
    }
}
