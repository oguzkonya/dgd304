using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AirSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public AirSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var air = _contexts.game.playerEntity.air.value;
        air += Time.deltaTime * GameConfig.Instance.airConsumption;

        if (air > 0)
        {
            _contexts.game.playerEntity.ReplaceAir(air);
        }
        else
        {
            var e = _contexts.game.CreateEntity();
            e.AddPlayerState(PlayerState.RunOutOfAir);
        }
    }
}