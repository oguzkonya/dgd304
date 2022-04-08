using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FireMovementSystem : IExecuteSystem, ICleanupSystem  
{
    private readonly Contexts _contexts;
    private IGroup<GameEntity> _fireEntities;

    public FireMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _fireEntities = _contexts.game.GetGroup(GameMatcher.Fire);
    }

    public void Cleanup()
    {
        foreach (var e in _fireEntities.GetEntities())
        {
            if (e.position.x > 10 || e.position.x < -10)
            {
                e.isToBeDestroyed = true;
            }
        }
    }

    public void Execute() 
    {
        foreach (var e in _fireEntities.GetEntities())
        {
            var x = e.position.x;
            x += Time.deltaTime * GameConfig.Instance.fireSpeed * (e.direction.value == Direction.Right ? 1 : -1);

            e.ReplacePosition(x, e.position.y, e.position.z);
        }
    }
}