using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

[Animation]
public class ValueAnimationComponent : IComponent
{
    public float from;
    public float to;
    public Easing.Functions easing;
    public Action<float> onUpdate;
}