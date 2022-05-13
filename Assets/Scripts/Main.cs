using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameController game;

    [SerializeField]
    private MenuManager menuManager;

    private void Awake()
    {
        instance = this;
        menuManager.Initialize();
        menuManager.Show<MainMenu>();
    }

    public void Play()
    {
        var go = new GameObject("GameController");
        game = go.AddComponent<GameController>();
        menuManager.Show<InGameMenu>();
    }

    public void EndGame()
    {
        Destroy(game.gameObject);
        menuManager.Show<EndGameMenu>();
    }
}
