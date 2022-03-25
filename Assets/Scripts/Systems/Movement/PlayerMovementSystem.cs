﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


public class PlayerMovementSystem : ReactiveSystem<GameEntity> 
{
	private Contexts _contexts;

	public PlayerMovementSystem(Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		// specify which component you are reacting to
		// return context.CreateCollector(MyContextMatcher.MyComponent);

		// you can also specify which type of event you need to react to

		// return context.CreateCollector(MyContextMatcher.MyComponent.Added()); // the default
		// return context.CreateCollector(MyContextMatcher.MyComponent.Removed());
		// return context.CreateCollector(MyContextMatcher.MyComponent.AddedOrRemoved());

		// combine matchers with AnyOf and AllOf
		// return context.CreateCollector(LevelMatcher.AnyOf(MyContextMatcher.Component1, MyContextMatcher.Component2));

		// use multiple matchers
		// return context.CreateCollector(LevelMatcher.MyContextMatcher, MyContextMatcher.Component2.Removed());

		// or any combination of all the above
		// return context.CreateCollector(LevelMatcher.AnyOf(MyContextMatcher.Component1, MyContextMatcher.Component2),
		//                                LevelMatcher.Component3.Removed(),
		//                                LevelMatcher.AllOf(MyContextMatcher.C4, MyContextMatcher.C5).Added());
		return null;
	}
		
	protected override bool Filter(GameEntity entity) 
	{
		// check for required components
		return true;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			// do stuff to the matched entities
		}
	}
}
