using System;
using System.Collections;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private float _countdownDelay;
    [SerializeField] private float _countdownStep;

    private GameStateMachine _stateMachine;
    private Coroutine _countingDown;
    private bool _isCountingDown = false;
    private bool _isPaused = false;
    private bool _hasLost = false;

    public event Action<int> CooldownUpdated;
    public event Action<bool> PauseToggled;

    public bool IsCountingDown => _isCountingDown;
    public bool IsPaused => _isPaused;
    public bool HasLost => _hasLost;

    private void Awake()
    {
        _stateMachine = GameStateMachineFactory.CreateGameStateMachine(this);
    }

    private void OnEnable()
    {
        _input.Paused += TogglePause;
    }

    private void Start()
    {
        _stateMachine.EnterState(typeof(CountdownState));
    }

    private void Update()
    {
        _stateMachine.UpdateState();
    }

    private void OnDisable()
    {
        _input.Paused -= TogglePause;
    }

    public void StartCountdown()
    {
        Time.timeScale = 0;

        if (_countingDown != null)
        {
            StopCoroutine(_countingDown);
        }

        _countingDown = StartCoroutine(CountingDown());
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        PauseToggled?.Invoke(_isPaused);
    }

    private void Loose()
    {
        _hasLost = true;
    }

    private IEnumerator CountingDown()
    {
        _isCountingDown = true;
        float countdown = _countdownDelay;
        CooldownUpdated?.Invoke((int)countdown);
        var wait = new WaitForSecondsRealtime(_countdownStep);

        while (countdown > 0)
        {
            yield return wait;
            countdown -= _countdownStep;
            CooldownUpdated?.Invoke((int)countdown);
        }

        _isCountingDown = false;
        Time.timeScale = 1;
        _countingDown = null;
    }
}
