using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AnimationSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<AnimationEntity> _animations;

    public AnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
        _animations = contexts.animation.GetGroup(AnimationMatcher.Animation);
    }

    public void Execute()
    {
        var entities = _animations.GetEntities();

        for (int i = entities.Length - 1; i >= 0; i--)
        {
            if (entities[i].animation.currentTime < entities[i].animation.duration)
            {
                entities[i].animation.currentTime += Time.deltaTime;
            }
            else
            {
                entities[i].Destroy();
            }
        }
    }
}