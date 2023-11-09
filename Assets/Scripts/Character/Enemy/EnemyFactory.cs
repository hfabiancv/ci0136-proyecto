using Object = UnityEngine.Object;

// include for Quaternion and Vector3
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Transform = UnityEngine.Transform;


namespace Enemies
{
    public class EnemyFactory
    {
        private readonly EnemyConfiguration _enemyConfiguration;

        public EnemyFactory(EnemyConfiguration enemyConfiguration)
        {
            _enemyConfiguration = enemyConfiguration;
        }
        // string id, position, rotation
        public Character Create(string id, Transform transform)
        {
            var enemy = _enemyConfiguration.GetEnemyPrefabById(id);
            return Object.Instantiate(enemy, transform.position, transform.rotation);
        }

    }
}
