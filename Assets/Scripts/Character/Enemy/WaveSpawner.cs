using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
 
    private Wave currentWave;
 
    [SerializeField]
    private Transform[] spawnpoints;
 
    private float spawnsWaitTime;
    private int i = 0;
 
    private bool stopSpawning = false;

    [SerializeField]
    private EnemyFactory _enemyFactory;

    private void Awake()
    {
        currentWave = waves[i];
        spawnsWaitTime = currentWave.TimeBeforeThisWave;
    }
 
    private void Update()
    {
        if(!stopSpawning)
        {
            if (Time.time >= spawnsWaitTime)
            {
                SpawnWave();
                IncrementWave();
    
                spawnsWaitTime = Time.time + currentWave.TimeBeforeThisWave;
            }
        }
    }
 
    private void SpawnWave()
    {
        _enemyFactory = new EnemyFactory(Instantiate(currentWave));
        for (int i = 0; i < currentWave.AmountToSpawn; i++)
        {
            int enemiesLength = currentWave.GetEnemiesLength();
            int enemyNum = Random.Range(0, enemiesLength);
            int spawnNum = Random.Range(0, spawnpoints.Length);
            string name = currentWave.GetEnemyIds()[enemyNum];
            Transform spawnpoint = spawnpoints[spawnNum];
            Character enemy = _enemyFactory.Create(name, spawnpoint);
        }
    }
 
    private void IncrementWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
 
}
