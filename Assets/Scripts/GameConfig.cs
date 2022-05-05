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

    public int enemySpawnMinY;
    public int enemySpawnMaxY;

    public float speed;
    public float playerSpeed;
    public float fireSpeed;

    public float gravity;
    public float initialAir;
    public float airConsumption;

    public float playerPosition;
    public float treasurePosition;

    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public GameObject firePrefab;
    public GameObject treasurePrefab;
}




