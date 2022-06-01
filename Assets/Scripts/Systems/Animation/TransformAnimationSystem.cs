using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TransformAnimationSystem : IExecuteSystem  
{
    private readonly Contexts _contexts;
    private readonly IGroup<AnimationEntity> _animations;

    public TransformAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
        _animations = contexts.animation.GetGroup(
            AnimationMatcher.AllOf(
                AnimationMatcher.Animation,
                AnimationMatcher.TransformAnimation
            ));
    }

    public void Execute() 
    {
        var entities = _animations.GetEntities();

        for (int i = entities.Length - 1; i >= 0 ; i--)
        {
            var target = entities[i].animation.targetEntity;

            var originX = entities[i].transformAnimation.originX;
            var originY = entities[i].transformAnimation.originY;
            var originZ = entities[i].transformAnimation.originZ;

            var targetX = entities[i].transformAnimation.targetX;
            var targetY = entities[i].transformAnimation.targetY;
            var targetZ = entities[i].transformAnimation.targetZ;

            var normalizedTime = entities[i].animation.currentTime / entities[i].animation.duration;
            var easing = entities[i].transformAnimation.easing;

            var newX = Tween.Do(originX, targetX, normalizedTime, easing);
            var newY = Tween.Do(originY, targetY, normalizedTime, easing);
            var newZ = Tween.Do(originZ, targetZ, normalizedTime, easing);

            if (target.hasPosition)
            {
                target.ReplacePosition(newX, newY, newZ);
            }
        }
    }
}