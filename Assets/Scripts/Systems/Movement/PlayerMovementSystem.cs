using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class PlayerMovementSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public PlayerMovementSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input.Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var x = _contexts.game.playerEntity.position.x;
            var y = _contexts.game.playerEntity.position.y;
            var z = _contexts.game.playerEntity.position.z;

            x += e.input.horizontal * Time.deltaTime * GameConfig.Instance.playerSpeed;
            y += e.input.vertical * Time.deltaTime * GameConfig.Instance.playerSpeed;

            _contexts.game.playerEntity.ReplacePosition(x, y, z);

            if (e.input.horizontal != 0)
            {
                _contexts.game.playerEntity.ReplaceDirection(e.input.horizontal > 0 ? Direction.Right : Direction.Left);
            }
        }
    }
}
