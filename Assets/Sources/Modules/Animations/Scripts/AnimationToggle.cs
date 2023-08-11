using UnityEngine;

namespace Shooting
{
    public class AnimationToggle : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _delay = 0.5f;

        private const string DeadCondition = "Dead";

        private void OnTriggerEnter2D(Collider2D other)
        {
            _animator.SetBool(DeadCondition, true);
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length + _delay);
        }
    }
}
