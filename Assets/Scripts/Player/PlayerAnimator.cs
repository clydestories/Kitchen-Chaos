using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private InputReader _input;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _input.Moved += SetMovementParametrs;
    }

    private void OnDisable()
    {
        _input.Moved -= SetMovementParametrs;
    }

    private void SetMovementParametrs(Vector2 input)
    {
        if (input.magnitude != 0)
        {
            _animator.SetBool(IsMoving, true);
        }
        else
        {
            _animator.SetBool(IsMoving, false);
        }
    }
}
