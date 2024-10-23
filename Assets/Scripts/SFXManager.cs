using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    [SerializeField] private DeliveryManager _deliveryManager;
    [SerializeField] private List<AudioClip> _successSounds;
    [SerializeField] private List<AudioClip> _failSounds;
    [SerializeField] private List<AudioClip> _warningSounds;
    [SerializeField] private float _minPitch = 0.9f;
    [SerializeField] private float _maxPitch = 1.1f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _deliveryManager.OrderCompleted += PlaySuccessSound;
        _deliveryManager.OrderCreated += PlayWarningSound;
        _deliveryManager.OrderFailed += PlayFailSound;
    }

    private void PlaySuccessSound(Order _)
    {
        PlaySound(_successSounds[Random.Range(0, _successSounds.Count)]);
    }

    private void PlayFailSound(Order _)
    {
        PlaySound(_failSounds[Random.Range(0, _failSounds.Count)]);
    }

    private void PlayWarningSound(Order _)
    {
        PlaySound(_warningSounds[Random.Range(0, _warningSounds.Count)]);
    }

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.Play();
    }
}
