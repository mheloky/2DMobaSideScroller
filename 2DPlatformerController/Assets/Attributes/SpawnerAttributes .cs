using UnityEngine;
using System;

[Serializable]
public class SpawnerAttributes
{   
   
    /// <summary>
    /// Most basic unit to spawn
    /// </summary>
    public GameObject SpawnUnit1;
    public float SpawnDelayInSeconds = 30;
    public float produceSettingSeconds = 1;
    public DateTime intervalCurrentTime = new DateTime();
    public DateTime produceCurrentTime = new DateTime();
    public int CreepsPerSpawn = 3;
    public string Team;
    public int spawnCount
    {
        get;
        set;
    }
}