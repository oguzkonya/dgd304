using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class PlayerStateComponent : IComponent
{
    public PlayerState value;
}

public enum PlayerState
{
    // Playing,
    RunOutOfAir,
    HitEnemy,
    CollectedTreasure
}