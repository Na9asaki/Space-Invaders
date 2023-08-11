using UnityEngine;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _reloadTime;
    
    private bool _active;
    private bool _buttonFire;
    private bool _weaponIsReady;
    private float _reloadTimer;

    private void ReadKey()
    {
        _buttonFire = Input.GetKeyDown(KeyCode.Space);
    }

    private void Update()
    {
        if (!_active)
            return;
        ReadKey();
        if (!_weaponIsReady)
        {
            _reloadTimer -= Time.deltaTime;
            if (_reloadTimer < 0)
            {
                _reloadTimer = _reloadTime;
                _weaponIsReady = true;
            }
        }
        if (_buttonFire && _weaponIsReady)
        {
            _weapon.Shoot();
            _weaponIsReady = false;
        }
    }

    public void Activate()
    {
        _active = true;
        _weaponIsReady = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
}
