using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


[CreateAssetMenu(fileName = "Wave", menuName = "Custom/Wave", order = 1)]
public class Wave : ScriptableObject
{
    [field: SerializeField]
    private Character[] EnemiesInWave { get; set; }
    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }
 
    [field: SerializeField]
    public int AmountToSpawn { get; private set; }

    private Dictionary<string, Character> _idCharacter;

    private void Awake()
    {
        _idCharacter = new Dictionary<string, Character>();
        foreach (var enemy in EnemiesInWave)
        {
            _idCharacter.Add(enemy.id, enemy);
        }
    }

    public string[] GetEnemyIds()
    {
        string[] ids = new string[EnemiesInWave.Length];
        for (int i = 0; i < EnemiesInWave.Length; i++)
        {
            ids[i] = EnemiesInWave[i].id;
        }   
        return ids;
    }

    public int GetEnemiesLength()
    {
        return EnemiesInWave.Length;
    }

    public Character GetEnemyPrefabById(string id)
    {
        if (!_idCharacter.TryGetValue(id, out var Enemy))
        {
            throw new Exception($"Enemy with id {id} does not exit");
        }

        return Enemy;
    }
}
