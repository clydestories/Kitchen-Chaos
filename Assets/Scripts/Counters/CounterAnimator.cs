using UnityEngine;

[RequireComponent (typeof(Animator))]
public class CounterAnimator : MonoBehaviour
{
    private readonly int Use = Animator.StringToHash(nameof(Use));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartUseAnimation()
    {
        _animator.SetTrigger(Use);
    }
}
