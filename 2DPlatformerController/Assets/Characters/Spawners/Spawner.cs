using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Assets.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour, IDamager
{
    public SpawnerAttributes spawnerAttributes = new SpawnerAttributes();
    public VitalityAttributes vitalityAttributes=new VitalityAttributes();
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
        enemyCreep.teamAttributes.Team = spawnerAttributes.Team;
        spawnerAttributes.SpawnUnit1.transform.position = new Vector3(this.transform.position.x + positionDelta , 4f);

        spawnerAttributes.spawnCount++;
    }

    public void TakeDamage(int damage)
    {
        return;
    }

    public DamagerAttributes GetDamagerAttributes()
    {
        return null;
    }

    public VitalityAttributes GetVitalityAttributes()
    {
        return vitalityAttributes;
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Slider GetHealthSlider()
    {
        throw new NotImplementedException();
    }
}
