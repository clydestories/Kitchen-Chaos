using UnityEngine;
using UnityEngine.UI;

public class ProgressDisplay : MonoBehaviour
{
    [SerializeField] private ProgressCounter _counter;
    [SerializeField] private Slider _bar;

    private void OnEnable()
    {
        _counter.ProgressUpdated += UpdateProgress;
    }

    private void OnDisable()
    {
        _counter.ProgressUpdated -= UpdateProgress;
    }

    private void UpdateProgress(float currentProgress, float maxProgress, bool isShowing)
    {
        _bar.gameObject.SetActive(isShowing); 
        _bar.value = currentProgress/maxProgress;
    }
}
