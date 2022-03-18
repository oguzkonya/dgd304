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
}
