using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MainContext
{
    Initalized,
    Play,
    End
}

public class Main : MonoBehaviour
{
    private static Main instance;
    public static Main Instance
    {
        get
        {
            return instance;
        }
    }

    public event Action<MainContext> MainHandle;

    private GameController game;

    private void Awake()
    {
        instance = this;
        //menuManager.Initialize();
        //menuManager.Show<MainMenu>();
    }

    private void Start()
    {
        MainHandle?.Invoke(MainContext.Initalized);
    }

    public void Play()
    {
        var go = new GameObject("GameController");
        game = go.AddComponent<GameController>();
        //menuManager.Show<InGameMenu>();
        MainHandle?.Invoke(MainContext.Play);
    }

    public void EndGame()
    {
        Destroy(game.gameObject);
        //menuManager.Show<EndGameMenu>();
        MainHandle?.Invoke(MainContext.End);
    }
}
