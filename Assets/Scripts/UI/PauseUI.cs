using DG.Tweening;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameStateManager _stateManager;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private float _scaleDuration;

    private Tween _disappear;

    private void OnEnable()
    {
        _stateManager.PauseToggled += OnPauseToggled;
    }

    private void Start()
    {
        _disappear = _pauseWindow.transform.DOScale(Vector3.zero, _scaleDuration).SetUpdate(true).SetEase(Ease.InBounce).SetAutoKill(false);
    }

    private void OnDisable()
    {
        _stateManager.PauseToggled += OnPauseToggled;
    }

    private void OnPauseToggled(bool isPaused)
    {
        if (isPaused)
        {
            _pauseWindow.SetActive(isPaused);
            _disappear.PlayBackwards();
        }
        else
        {
            _disappear.OnComplete(() => _pauseWindow.SetActive(isPaused));
            _disappear.PlayForward();
        }
    }
}
