using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Animation]
public class AnimationComponent : IComponent
{
    public GameEntity targetEntity;
    public float currentTime;
    public float duration;
}