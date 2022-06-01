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
            .Add(new InitializeTreasureSystem(Contexts.sharedInstance))

            .Add(new ResourceSystem(Contexts.sharedInstance))
            .Add(new FireSystem(Contexts.sharedInstance))
            
            .Add(new PlayerMovementSystem(Contexts.sharedInstance))
            .Add(new EnemyMovementSystem(Contexts.sharedInstance))
            .Add(new FireMovementSystem(Contexts.sharedInstance))
            .Add(new GravitySystem(Contexts.sharedInstance))
            .Add(new AirSystem(Contexts.sharedInstance))

            .Add(new AnimationSystem(Contexts.sharedInstance))
            .Add(new TransformAnimationSystem(Contexts.sharedInstance))
            
            .Add(new GameEventSystems(Contexts.sharedInstance))
            
            .Add(new PlayerStateSystem(Contexts.sharedInstance))
            .Add(new DestroySystem(Contexts.sharedInstance))
            .Add(new GameStateSystem(Contexts.sharedInstance))
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
        _systems.DeactivateReactiveSystems();
        _systems.ClearReactiveSystems();
    }
}
