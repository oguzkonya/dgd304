using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    private Systems _systems;

    private void Start()
    {
        _systems = new Feature("Systems")
            .Add(new KeyboardInputSystem(Contexts.sharedInstance))

            .Add(new InitializeGameSystem(Contexts.sharedInstance))
            .Add(new InitializePlayerSystem(Contexts.sharedInstance))
            .Add(new InitializeEnemySystem(Contexts.sharedInstance))

            .Add(new ResourceSystem(Contexts.sharedInstance))
            .Add(new PlayerMovementSystem(Contexts.sharedInstance))
            .Add(new EnemyMovementSystem(Contexts.sharedInstance))
            
            .Add(new GameEventSystems(Contexts.sharedInstance))
            ;

        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy() 
    {
        _systems.TearDown();
    }
}
