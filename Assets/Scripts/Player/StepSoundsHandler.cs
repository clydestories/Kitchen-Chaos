using System.Collections.Generic;
using UnityEngine;

public class StepSoundsHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Mover _mover;
    [SerializeField] private List<AudioClip> _stepSounds;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;

    private void OnEnable()
    {
        _mover.Moved += PlayStepSound;
    }

    private void OnDisable()
    {
        _mover.Moved -= PlayStepSound;
    }

    private void PlayStepSound(Vector2 direction)
    {
        if (direction != Vector2.zero && _audioSource.isPlaying == false)
        {
            _audioSource.clip = _stepSounds[Random.Range(0, _stepSounds.Count)];
            _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
            _audioSource.Play();
        }
    }
}
