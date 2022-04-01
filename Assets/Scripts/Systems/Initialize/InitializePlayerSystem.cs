using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitializePlayerSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
        var e = _contexts.game.CreateEntity();
        e.AddPosition(0, 0, 0);
        e.AddResource(GameConfig.Instance.playerPrefab);
        e.AddDirection(Direction.Right);
        e.isPlayer = true;
    }
}