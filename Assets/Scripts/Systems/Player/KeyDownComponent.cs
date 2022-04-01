using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Input]
public class KeyDownComponent : IComponent
{
    public KeyCode keyCode;
}