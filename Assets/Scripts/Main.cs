using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameController game;

    public void Play()
    {
        var go = new GameObject("GameController");
        game = go.AddComponent<GameController>();
    }

    public void EndGame()
    {
        Destroy(game);
    }
}
