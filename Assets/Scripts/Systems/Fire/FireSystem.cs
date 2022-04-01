using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class FireSystem : ReactiveSystem<InputEntity> 
{
	private Contexts _contexts;

	public FireSystem(Contexts contexts) : base(contexts.input) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) 
	{
		return context.CreateCollector(InputMatcher.KeyDown.Added());
	}
		
	protected override bool Filter(InputEntity entity) 
	{
		return true;
	}

	protected override void Execute(List<InputEntity> entities) 
	{
		var e = _contexts.game.CreateEntity();
		e.AddResource(GameConfig.Instance.firePrefab);
		e.isFire = true;
	}
}
