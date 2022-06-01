using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Animation]
public class TransformAnimationComponent : IComponent
{
    public float originX;
    public float originY;
    public float originZ;

    public float targetX;
    public float targetY;
    public float targetZ;

    public Easing.Functions easing;
}