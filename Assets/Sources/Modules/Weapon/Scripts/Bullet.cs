using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private Vector2 _direction;

    private float _deathTimer = 0f;

    private void Update()
    {
        _deathTimer += Time.deltaTime;
        if (_deathTimer > _lifetime)
        {
            Destroy(gameObject);
        }
        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}
