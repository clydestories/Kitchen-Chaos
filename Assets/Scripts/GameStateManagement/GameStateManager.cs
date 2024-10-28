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

    public bool IsCountingDown => _isCountingDown;
    public bool IsPaused => _isPaused;
    public bool HasLost => _hasLost;

    private void Awake()
    {
        _stateMachine = GameStateMachineFactory.CreateGameStateMachine(this);
    }

    private void OnEnable()
    {
        _input.Paused += HandlePause;
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
        _input.Paused -= HandlePause;
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

    private void HandlePause()
    {
        _isPaused = !_isPaused;
    }

    private void Loose()
    {
        _hasLost = true;
    }

    private IEnumerator CountingDown()
    {
        _isCountingDown = true;
        float countdown = _countdownDelay;
        var wait = new WaitForSecondsRealtime(_countdownStep);

        while (countdown > 0)
        {
            yield return wait;
            countdown -= _countdownStep;
        }

        _isCountingDown = false;
        Time.timeScale = 1;
        _countingDown = null;
    }
}
