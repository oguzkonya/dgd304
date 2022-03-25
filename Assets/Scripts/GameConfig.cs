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

    public float range;

    public float speed;

    public float minY;
    public float maxY;

    public GameObject enemyPrefab;
    public GameObject playerPrefab;
}




