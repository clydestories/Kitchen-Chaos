using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private List<KeyCode> _interactKeys;
    [SerializeField] private List<KeyCode> _useKeys;

    public event Action<Vector2> Moved;
    public event Action Interacted;
    public event Action Used;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(Horizontal);
        float verticalInput = Input.GetAxisRaw(Vertical);

        Moved?.Invoke(new Vector2(horizontalInput, verticalInput).normalized);

        foreach (KeyCode keyCode in _interactKeys) 
        {
            if (Input.GetKeyDown(keyCode))
            {
                Interacted?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _useKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Used?.Invoke();
            }
        }
    }
}
