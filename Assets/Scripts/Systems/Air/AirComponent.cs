using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class AirComponent : IComponent
{
    public float value;
}