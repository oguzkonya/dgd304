using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GravitySystem : IExecuteSystem  
{
    private readonly Contexts _contexts;

    public GravitySystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute() 
    {
        var x = _contexts.game.playerEntity.position.x;
        var y = _contexts.game.playerEntity.position.y;
        var z = _contexts.game.playerEntity.position.z;
        y += Time.deltaTime * GameConfig.Instance.gravity;

        _contexts.game.playerEntity.ReplacePosition(x, y, z);
    }
}