using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class GameStateComponent : IComponent
{
    public GameState value;
}

public enum GameState
{
    Won,
    Lost
}