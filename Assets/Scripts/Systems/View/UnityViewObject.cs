using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class UnityViewObject : MonoBehaviour, IPositionListener
{
    private GameEntity linkedEntity;

    public void Link(GameEntity entity)
    {
        linkedEntity = entity;
        gameObject.Link(entity);
        linkedEntity.AddPositionListener(this);
    }

    public void OnPosition(GameEntity entity, float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameEntity otherEntity = other.gameObject.GetEntityLink().entity as GameEntity;

        if ((otherEntity.isPlayer && linkedEntity.isEnemy) || 
            (otherEntity.isEnemy && linkedEntity.isPlayer))
        {
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddPlayerState(PlayerState.HitEnemy);
        }

        // linkedEntity.isToBeDestroyed = true;
        // destroy objects -> fire - enemy collision
        // win game -> player - treasure collision
    }
}
