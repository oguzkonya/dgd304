using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitializeGameSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializeGameSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize() 
    {
    }
}






