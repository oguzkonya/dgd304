using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class AnimParamBoolComponent : IComponent
{
    public string name;
    public bool value;
}