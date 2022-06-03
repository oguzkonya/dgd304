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
		e.AddDirection(_contexts.game.playerEntity.direction.value);
		
		var position = _contexts.game.playerEntity.position;
		e.AddPosition(position.x, position.y, position.z);

		e.isFire = true;

		// Trigger animation
		// _contexts.game.playerEntity.ReplaceAnimParamTrigger("redValue");

		// Bool animation
		// bool v = false;

		// if (_contexts.game.playerEntity.hasAnimParamBool)
		// {
		// 	v = _contexts.game.playerEntity.animParamBool.value;
		// }

		// _contexts.game.playerEntity.ReplaceAnimParamBool("tinyValue", !v);
		
		// Integer animation
		int v = 0;

		if (_contexts.game.playerEntity.hasAnimParamInt)
		{
			v = _contexts.game.playerEntity.animParamInt.value;
		}

		_contexts.game.playerEntity.ReplaceAnimParamInt("diamondValue", (v + 1) % 2);
	}
}





