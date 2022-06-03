using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class UnityViewObject : MonoBehaviour, IPositionListener, IAnimParamBoolListener, IAnimParamFloatListener, IAnimParamIntListener, IAnimParamTriggerListener
{
    private GameEntity linkedEntity;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Link(GameEntity entity)
    {
        linkedEntity = entity;
        gameObject.Link(entity);
        linkedEntity.AddPositionListener(this);
        linkedEntity.AddAnimParamBoolListener(this);
        linkedEntity.AddAnimParamFloatListener(this);
        linkedEntity.AddAnimParamIntListener(this);
        linkedEntity.AddAnimParamTriggerListener(this);
    }

    public void OnAnimParamBool(GameEntity entity, string name, bool value)
    {
        if (animator != null)
        {
            animator.SetBool(name, value);
        }
    }

    public void OnAnimParamFloat(GameEntity entity, string name, float value)
    {
        if (animator != null)
        {
            animator.SetFloat(name, value);
        }
    }

    public void OnAnimParamInt(GameEntity entity, string name, int value)
    {
        if (animator != null)
        {
            animator.SetInteger(name, value);
        }
    }

    public void OnAnimParamTrigger(GameEntity entity, string name)
    {
        if (animator != null)
        {
            animator.SetTrigger(name);
        }
    }

    public void OnPosition(GameEntity entity, float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameEntity otherEntity = other.gameObject.GetEntityLink().entity as GameEntity;

        if (linkedEntity.isPlayer)
        {
            if (otherEntity.isEnemy)
            {
                var e = Contexts.sharedInstance.game.CreateEntity();
                e.AddPlayerState(PlayerState.HitEnemy);
            }
            else if (otherEntity.isTreasure)
            {
                var e = Contexts.sharedInstance.game.CreateEntity();
                e.AddPlayerState(PlayerState.CollectedTreasure);
            }
        }

        if ((linkedEntity.isFire && otherEntity.isEnemy) ||
            (linkedEntity.isEnemy && otherEntity.isFire))
        {
            linkedEntity.isToBeDestroyed = true;
        }
    }
}
