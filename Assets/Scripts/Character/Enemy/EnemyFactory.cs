using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        private readonly EnemyConfiguration _enemyConfiguration;

        public EnemyFactory(EnemyConfiguration enemyConfiguration)
        {
            _enemyConfiguration = enemyConfiguration;
        }

        public Character Create(string id)
        {
            var enemy = _enemyConfiguration.GetEnemyPrefabById(id);
            return Object.Instantiate(enemy);
        }
    }
}
