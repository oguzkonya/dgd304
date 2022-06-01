using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class InitializeGameSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializeGameSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
        var gameEntity = _contexts.game.CreateEntity();
        gameEntity.AddResource(GameConfig.Instance.enemyPrefab);
        gameEntity.AddPosition(0, 0, 0);

        var e = _contexts.animation.CreateEntity();
        e.AddAnimation(gameEntity, 0, 5);
        e.AddTransformAnimation(
            0, 0, 0,
            5, 0, 0,
            Easing.Functions.ElasticEaseInOut
        );

        var ef = _contexts.animation.CreateEntity();
        e.AddValueAnimation(100, 200, Easing.Functions.Linear, OnUpdateValue);
    }

    private void OnUpdateValue(float value)
    {
        Debug.Log(value);
    }
}






