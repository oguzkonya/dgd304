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
            var speed = Random.Range(GameConfig.Instance.minSpeed, GameConfig.Instance.maxSpeed);
            var range = Random.Range(GameConfig.Instance.minRange, GameConfig.Instance.maxRange);
            var x = Mathf.Cos(Time.time * speed) * range;

            _enemyEntity.ReplacePosition(
                x, 
                _enemyEntity.position.y, 
                _enemyEntity.position.z);
        }
    }
}