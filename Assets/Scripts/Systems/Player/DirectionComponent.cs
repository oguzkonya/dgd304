using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class DirectionComponent : IComponent
{
    public Direction value;
}

public enum Direction
{
    Left,
    Right
}