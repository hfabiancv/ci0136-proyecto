using Object = UnityEngine.Object;

// include for Quaternion and Vector3
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Transform = UnityEngine.Transform;


namespace Enemies
{
    public class EnemyFactory
    {
        private readonly Wave _wave;

        public EnemyFactory(Wave wave)
        {
            _wave = wave;
        }
    
        
        public Character Create(string id, Transform transform)
        {
            var enemy = _wave.GetEnemyPrefabById(id);
            // Could be used to play an animation
            enemy.Test();
            return Object.Instantiate(enemy, transform.position, transform.rotation);
        }

    }
}
