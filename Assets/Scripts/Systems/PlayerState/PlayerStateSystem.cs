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
					
					// Destroy all entities
					// EndGame()

					break;

				case PlayerState.CollectedTreasure:

					break;
			}
		}
	}
}
