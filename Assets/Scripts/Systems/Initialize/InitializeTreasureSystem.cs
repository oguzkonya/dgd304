using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitializeTreasureSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializeTreasureSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
        var e = _contexts.game.CreateEntity();
        e.AddPosition(0, GameConfig.Instance.treasurePosition, 0);
        e.AddResource(GameConfig.Instance.treasurePrefab);
    }
}