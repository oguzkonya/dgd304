using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;


public class DestroySystem : ReactiveSystem<GameEntity> 
{
	private Contexts _contexts;

	public DestroySystem(Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.ToBeDestroyed.Added());
	}
		
	protected override bool Filter(GameEntity entity) 
	{
		return entity.hasUnityView;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			e.unityView.value.gameObject.Unlink();
			GameObject.Destroy(e.unityView.value.gameObject);
			e.Destroy();
		}
	}
}
