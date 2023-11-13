using Enemies;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _minimumID;

    [SerializeField]
    private float _maximumID;
    [SerializeField]
    private EnemyFactory _enemyFactory;

    [SerializeField]
    private EnemyConfiguration _enemyConfiguration;

    // Enemy spawner transform
    private Transform _spawnerTransform;

     [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;

    private string[] _enemyNames;

    void Awake()
    {
        SetTimeUntilSpawn(); 
    }

    void Update() 
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0) {
            SpawnEnemy();
            SetTimeUntilSpawn();
        } 
    }

    void SpawnEnemy() 
    {
        _enemyNames = _enemyConfiguration.GetEnemyIds();      
        _spawnerTransform = GetComponent<Transform>();
        _enemyFactory = new EnemyFactory(Instantiate(_enemyConfiguration));
        int enemyId = ((int)Random.Range(_minimumID, _maximumID));

        string name = _enemyNames[enemyId - 1];

        Debug.Log(enemyId);
        Character enemy = _enemyFactory.Create(name, _spawnerTransform);
    }

     private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}