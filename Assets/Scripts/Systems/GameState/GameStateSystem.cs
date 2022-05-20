using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class GameStateSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public GameStateSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameState.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            switch (e.gameState.value)
            {
                case GameState.Lost:
					Main.Instance.EndGame(false);
                    break;

                case GameState.Won:
					Main.Instance.EndGame(true);
                    break;
            }

			e.Destroy();
        }
    }
}
