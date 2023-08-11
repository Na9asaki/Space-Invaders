using Enemies;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CharacterInput _characterInput;
    [SerializeField] private WeaponInput _weaponInput;
    [SerializeField] private EnemiesBehaivor enemiesBehaivor;
    void Start()
    {
        _characterInput.Activate();
        _weaponInput.Activate();
        enemiesBehaivor.Activate();
    }
}
