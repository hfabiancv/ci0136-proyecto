using Enemies;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _minimumID;

    [SerializeField]
    private float _maximumID;

    private EnemyFactory _enemyFactory;

    [SerializeField]
    private EnemyConfiguration _enemyConfiguration;

    void Awake()
    {
        _enemyFactory = new EnemyFactory(Instantiate(_enemyConfiguration));
        int enemyId = ((int)Random.Range(_minimumID, _maximumID));
        Debug.Log(enemyId);
        switch (enemyId)
        {
            case 1:
                Character weak = _enemyFactory.Create("Weak");
                break;
            case 2:
                Character normal = _enemyFactory.Create("Normal");
                break;
            case 3:
                Character superior = _enemyFactory.Create("Superior");
                break;
            default:
                Debug.Log("Default" + enemyId);
                break;

        }
    }

    void Update()
    {
        
    }
}