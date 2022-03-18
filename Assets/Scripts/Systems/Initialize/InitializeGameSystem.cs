using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitializeGameSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializeGameSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
        for (int i = 0; i < 10; i++)
        {
            CreateEnemy();
        }
    }

    public void CreateEnemy()
    {
        var e = _contexts.game.CreateEntity();
        e.AddPosition(0, 0, 0);
        e.isEnemy = true;
        e.AddResource(GameConfig.Instance.enemyPrefab);
    }
}






