using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class KeyboardInputSystem : IExecuteSystem, ICleanupSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<InputEntity> _inputs;

    public KeyboardInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _inputs = _contexts.input.GetGroup(InputMatcher.AnyOf(InputMatcher.Input, InputMatcher.KeyDown));
    }

    public void Execute() 
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0) 
        {
            var e = _contexts.input.CreateEntity();
            e.AddInput(h, v);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var e = _contexts.input.CreateEntity();
            e.AddKeyDown(KeyCode.Space);
        }
    }

    public void Cleanup()
    {
        foreach (var e in _inputs.GetEntities())
        {
            e.Destroy();
        }
    }
}








