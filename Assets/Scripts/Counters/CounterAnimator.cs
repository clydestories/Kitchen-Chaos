using UnityEngine;

[RequireComponent (typeof(Animator))]
public class CounterAnimator : MonoBehaviour
{
    private readonly int Use = Animator.StringToHash(nameof(Use));
    private readonly int IsOn = Animator.StringToHash(nameof(IsOn));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartUseAnimation()
    {
        _animator.SetTrigger(Use);
    }

    public void TurnCounterOn()
    {
        _animator.SetBool(IsOn, true);
    }

    public void TurnCounterOff()
    {
        _animator.SetBool(IsOn, false);
    }
}
