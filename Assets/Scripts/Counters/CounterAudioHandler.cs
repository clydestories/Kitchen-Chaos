using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class CounterAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _continuousUseSound;
    [SerializeField] private List<AudioClip> _useSounds;
    [SerializeField] private List<AudioClip> _interactTakeSounds;
    [SerializeField] private List<AudioClip> _interactGiveSounds;
    [SerializeField] private float _minPitch = 0.9f;
    [SerializeField] private float _maxPitch = 1.1f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayUseSound()
    {
        PlaySound(_useSounds[Random.Range(0, _useSounds.Count)]);
    }

    public void PlayInteractTakeSound()
    {
        PlaySound(_interactTakeSounds[Random.Range(0, _interactTakeSounds.Count)]);
    }

    public void PlayInteractGiveSound()
    {
        PlaySound(_interactGiveSounds[Random.Range(0, _interactGiveSounds.Count)]);
    }

    public void StartContinuousUseSound()
    {
        PlaySound(_continuousUseSound);
    }

    public void StopContinuousUseSound()
    {
        _audioSource.Stop();
    }

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.Play();
    }
}
