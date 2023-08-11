using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    private const string Horizontal = "Horizontal";
    private float _moveDirection;

    private bool _active;

    private void ReadKeys()
    {
        _moveDirection = Input.GetAxisRaw(Horizontal);
    }

    private void Update()
    {
        if (!_active)
            return;
        ReadKeys();
        _characterMovement.Move(_moveDirection);
    }

    public void Activate()
    {
        _active = true;
        _characterMovement.Init();
    }

    public void Deactivate()
    {
        _active = false;
    }
}
