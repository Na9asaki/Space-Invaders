using System;
using UnityEngine;

namespace Enemies
{
    internal class Enemy : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        public static event Action<Enemy> DeadEnemyEvent;
        
        internal void Shoot()
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }

        internal void OnDestroy()
        {
            DeadEnemyEvent?.Invoke(this);
        }
    }
}
