using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class KeyboardInputSystem : IExecuteSystem  
{
    private readonly Contexts _contexts;

    public KeyboardInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute() 
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
    }
}