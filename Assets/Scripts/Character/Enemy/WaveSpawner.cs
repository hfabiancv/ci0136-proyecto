using Enemies;
using System;
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

    private int enemiesRemaining;

    public event EventHandler OnBattleStarted;
    public event EventHandler OnBattleOver;

    [SerializeField] private ColliderTrigger colliderTrigger;

    private void Awake()
    {
        currentWave = waves[i];
        spawnsWaitTime = currentWave.TimeBeforeThisWave;
        enemiesRemaining = 0;
        colliderTrigger.OnPlayerEnterTrigger += StartBattle;
    }

    private void StartBattle(object sender, EventArgs e)
    {
        colliderTrigger.OnPlayerEnterTrigger -= StartBattle;
        OnBattleStarted?.Invoke(this, EventArgs.Empty);
        StartNextWave();
    }

    private void StartNextWave()
    {
        if (!stopSpawning) {
            SpawnWave();
            IncrementWave();
        } else {
            if (enemiesRemaining <= 0) {
                Debug.Log("Battle over!");
                OnBattleOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }
 
    private void SpawnWave()
    {
        _enemyFactory = new EnemyFactory(Instantiate(currentWave));
        enemiesRemaining = currentWave.AmountToSpawn; 
        for (int i = 0; i < currentWave.AmountToSpawn; i++)
        {
            int enemiesLength = currentWave.GetEnemiesLength();
            int enemyNum = UnityEngine.Random.Range(0, enemiesLength);
            int spawnNum = UnityEngine.Random.Range(0, spawnpoints.Length);
            string name = currentWave.GetEnemyIds()[enemyNum];
            Transform spawnpoint = spawnpoints[spawnNum];
            Character enemy = _enemyFactory.Create(name, spawnpoint);
            enemy.OnCharacterDied += OnEnemyDied;
        }
    }

    private void OnEnemyDied(object sender, System.EventArgs e)
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0) {
            Debug.Log("Wave over!");
            StartNextWave();
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
