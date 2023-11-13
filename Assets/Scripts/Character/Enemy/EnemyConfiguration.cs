using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Custom/Enemy configuration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private Character[] _character;
        private Dictionary<string, Character> _idCharacter;

        private void Awake()
        {

            _idCharacter = new Dictionary<string, Character>();
            foreach (var enemy in _character)
            {
                _idCharacter.Add(enemy.id, enemy);
            }
        }

        public Character GetEnemyPrefabById(string id)
        {
            if (!_idCharacter.TryGetValue(id, out var Enemy))
            {
                throw new Exception($"Enemy with id {id} does not exit");
            }

            return Enemy;
        }

  
        public string[] GetEnemyIds()
        {
            string[] ids = new string[_character.Length];
            for (int i = 0; i < _character.Length; i++)
            {
                ids[i] = _character[i].id;
            }   
            return ids;
        }
    }
}