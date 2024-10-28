using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private List<KeyCode> _interactKeys;
    [SerializeField] private List<KeyCode> _useKeys;
    [SerializeField] private List<KeyCode> _pauseKeys;

    public event Action<Vector2> Moved;
    public event Action Interacted;
    public event Action Used;
    public event Action Paused;

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

        foreach (KeyCode keyCode in _pauseKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Paused?.Invoke();
            }
        }
    }
}
