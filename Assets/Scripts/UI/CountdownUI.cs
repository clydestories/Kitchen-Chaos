using DG.Tweening;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private GameStateManager _stateManager;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _scaleDuration;

    private Sequence _bounce;
    private int _bounceMoves = 2;

    private void Awake()
    {
        _bounce = DOTween.Sequence();
    }

    private void OnEnable()
    {
        _stateManager.CooldownUpdated += OnCountdownUpdate;
    }

    private void Start()
    {
        Vector3 originalScale = _text.transform.localScale;
        _bounce.Append(_text.transform.DOScale(originalScale * _scaleMultiplier, _scaleDuration / _bounceMoves).SetLoops(_bounceMoves, LoopType.Yoyo));
    }

    private void OnDisable()
    {
        _stateManager.CooldownUpdated += OnCountdownUpdate;
    }

    private void OnCountdownUpdate(int amount)
    {
        _text.text = amount.ToString();

        if (_bounce.playedOnce == false)
        {
            _bounce.Play().SetUpdate(true).SetAutoKill(false);
        }
        else
        {
            _bounce.Restart();
        }

        if (amount == 0)
        {
            _text.gameObject.SetActive(false);
        }
        else
        {
            _text.gameObject.SetActive(true);
        }
    }
}
