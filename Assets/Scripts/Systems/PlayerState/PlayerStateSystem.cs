using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class PlayerStateSystem : ReactiveSystem<GameEntity> 
{
	private Contexts _contexts;

	public PlayerStateSystem(Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.PlayerState.Added());
	}
		
	protected override bool Filter(GameEntity entity) 
	{
		return entity.hasPlayerState;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			switch (e.playerState.value)
			{
				case PlayerState.RunOutOfAir:
				case PlayerState.HitEnemy:
					
					var gameEntities = _contexts.game.GetEntities();

					foreach (var g in gameEntities)
					{
						g.isToBeDestroyed = true;
					}

					var lost = _contexts.game.CreateEntity();
					lost.AddGameState(GameState.Lost);
					break;

				case PlayerState.CollectedTreasure:
					var won = _contexts.game.CreateEntity();
					won.AddGameState(GameState.Won);
					break;
			}

			e.Destroy();
		}
	}
}
