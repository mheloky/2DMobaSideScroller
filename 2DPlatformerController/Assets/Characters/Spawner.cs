using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour, IDamagable
{
    public SpawnerAttributes spawnerAttributes = new SpawnerAttributes();
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if((DateTime.Now- spawnerAttributes.intervalCurrentTime).TotalSeconds>= spawnerAttributes.SpawnDelayInSeconds
            && (DateTime.Now- spawnerAttributes.produceCurrentTime).TotalSeconds >= spawnerAttributes.produceSettingSeconds)
        {
            SpawnCreeps();

            spawnerAttributes.produceCurrentTime = DateTime.Now;
            if (spawnerAttributes.spawnCount == spawnerAttributes.CreepsPerSpawn)
            {
                spawnerAttributes.intervalCurrentTime = DateTime.Now;
                spawnerAttributes.spawnCount = 0;
            }
        }
    }

    public void SpawnCreeps()
    {
        var positionDelta = 10;
        if (spawnerAttributes.Team == TAGS.Team2)
                positionDelta = -10;

        var enemyCreepRawObj = Instantiate(spawnerAttributes.SpawnUnit1);
        var enemyCreep = enemyCreepRawObj.GetComponent<EnemyCreep>();
        enemyCreep.damagableAttributes.Team = spawnerAttributes.Team;
        spawnerAttributes.SpawnUnit1.transform.position = new Vector3(this.transform.position.x + positionDelta , 4f);

        spawnerAttributes.spawnCount++;
    }

    public void TakeDamage(int damage)
    {
        return;
    }

    public DamagableAttributes GetDamagableAttributes()
    {
        return null;
    }
}
