using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameConfig : ScriptableObject
{
    private static GameConfig _instance;

    public static GameConfig Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GameConfig>("GameConfig");
            }

            return _instance;
        }
    }

    [Header("Values")]
    public float range;

    public float minY;
    public float maxY;

    public float speed;
    public float playerSpeed;
    public float fireSpeed;

    public float gravity;
    public float initialAir;
    public float airConsumption;

    public float treasurePosition;

    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public GameObject firePrefab;
    public GameObject treasurePrefab;
}




