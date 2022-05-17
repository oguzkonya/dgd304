using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField]
    public Button playButton;

    protected override void OnInitialize()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        Main.Instance.MainHandle += OnMainHandleUpdated; // <-- need refactor, singleton causes coupling.
    }

    private void OnMainHandleUpdated(MainContext context)
    {
        switch (context) 
        {
            case MainContext.Initalized:
                Show();
                break;
            case MainContext.Play:
                Hide();
                break;
        }
    }

    private void OnPlayButtonClicked()
    {
        Main.Instance.Play(); // <-- need refactor
    }
}
