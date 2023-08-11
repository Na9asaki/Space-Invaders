using System;
using UnityEngine;

[Serializable]
internal class CharacterMovement
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Vector2 _borders;
    private Vector3 _moveDirection;

    internal void Move(float inputDirection)
    {
        if (_characterTransform.position.x + inputDirection < _borders.x || _characterTransform.position.x + inputDirection > _borders.y)
            return;
        _moveDirection.Set(inputDirection, 0f, 0f);
        _characterTransform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    internal void Init()
    {
        _moveDirection = new Vector3();
    }
}
