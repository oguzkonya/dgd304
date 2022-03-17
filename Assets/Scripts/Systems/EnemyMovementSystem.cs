using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemyMovementSystem : IExecuteSystem  
{
    private readonly Contexts _contexts;
    private IGroup<GameEntity> _enemyEntities;

    public EnemyMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _enemyEntities = _contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute() 
    {
        foreach (var _enemyEntity in _enemyEntities)
        {
            _enemyEntity.ReplacePosition(
                Mathf.Cos(Time.time), 
                _enemyEntity.position.y, 
                _enemyEntity.position.z);
        }
    }
}