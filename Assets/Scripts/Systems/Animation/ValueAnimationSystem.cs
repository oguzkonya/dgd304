using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ValueAnimationSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<AnimationEntity> _animations;

    public ValueAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
        _animations = contexts.animation.GetGroup(
            AnimationMatcher.AllOf(
                AnimationMatcher.Animation,
                AnimationMatcher.ValueAnimation
            ));
    }

    public void Execute()
    {
        var entities = _animations.GetEntities();

        for (int i = entities.Length - 1; i >= 0; i--)
        {
            var target = entities[i].animation.targetEntity;
            var from = entities[i].valueAnimation.from;
            var to = entities[i].valueAnimation.to;

            var normalizedTime = entities[i].animation.currentTime / entities[i].animation.duration;
            var easing = entities[i].valueAnimation.easing;

            var newValue = Tween.Do(from, to, normalizedTime, easing);

            entities[i].valueAnimation.onUpdate?.Invoke(newValue);
        }
    }
}