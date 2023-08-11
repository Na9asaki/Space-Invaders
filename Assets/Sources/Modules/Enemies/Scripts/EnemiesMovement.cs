using UnityEngine;

internal class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private Transform _allPositions;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _borders;

    private (Vector3, Vector3) _directionMove = (Vector3.left, Vector3.right);
    private Vector3 _directionCondition;

    private bool _active;

    private void Update()
    {
        if (!_active)
            return;
        if (_allPositions.position.x <= _borders.x)
        {
            _directionCondition = _directionMove.Item2;
            _allPositions.Translate(Vector3.down);
        } else if (_allPositions.position.x >= _borders.y)
        {
            _directionCondition = _directionMove.Item1;
            _allPositions.Translate(Vector3.down);
        }
        _allPositions.Translate(_directionCondition * Time.deltaTime * _speed);
    }

    public void Activate()
    {
        _active = true;
        _directionCondition = _directionMove.Item1;
    }

    public void Deactivate()
    {
        _active = false;
    }
}
