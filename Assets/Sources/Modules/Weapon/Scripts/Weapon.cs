using UnityEngine;

internal class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPosition;

    internal void Shoot()
    {
        Instantiate(_bullet, _shootPosition.position, _shootPosition.rotation);
    }
}
