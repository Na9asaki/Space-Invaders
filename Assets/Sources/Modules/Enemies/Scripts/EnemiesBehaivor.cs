using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemiesBehaivor : MonoBehaviour
    {
        [SerializeField] private Transform[] _positions;
        [SerializeField] private EnemiesMovement _enemiesMovement;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _reloadTime;
        
        private bool _active;
        private bool _shootIsReady;
        private int index;
        private float _reloadTimer;
        
        private List<Enemy> _enemies;
        private int[] _lastLayerOfEnemies;

        private void OnEnable()
        {
            Enemy.DeadEnemyEvent += DeleteEnemy;
        }

        private void OnDisable()
        {
            Enemy.DeadEnemyEvent -= DeleteEnemy;
        }

        private void Update()
        {
            if (!_active)
                return;
            _reloadTimer -= Time.deltaTime;
            if (_reloadTimer <= 0)
            {
                _shootIsReady = true;
                _reloadTimer = _reloadTime;
            }
            if (_shootIsReady)
            {
                _enemies[index].Shoot();
                index = Random.Range(0, _enemies.Length);
                _shootIsReady = false;
            }
        }

        private void DeleteEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
        
        public void Activate()
        {
            _enemies = new List<Enemy>(_positions.Length);
            _lastLayerOfEnemies = new int[11];
            for (int i = 0; i < _lastLayerOfEnemies.Length; i++)
            {
                _lastLayerOfEnemies[i] = 5;
            }
            for (int i = 0; i < _positions.Length; i++)
            {
                _enemies[i] = Instantiate(_enemy, _positions[i].position, _positions[i].rotation, transform);
            }
            _shootIsReady = true;
            index = Random.Range(0, _lastLayerOfEnemies.Length);
            _enemiesMovement.Activate();
            _active = true;
        }

        public void Deactivate()
        {
            _active = false;
        }
    }
}
