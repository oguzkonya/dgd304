using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : Menu
{
    public Button replayButton;
    public TextMeshProUGUI endGameText; 

    protected override void OnInitialize()
    {
        replayButton.onClick.AddListener(OnReplayButtonClicked);
    }

    protected override void OnBeforeShow(object data)
    {
        bool hasWon = (bool)data;

        endGameText.text = hasWon 
            ? "YOU WIN" 
            : "YOU LOSE";
    }

    private void OnReplayButtonClicked()
    {
        Main.Instance.Play();
    }
}
