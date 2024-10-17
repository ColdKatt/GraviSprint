using System;
using System.Linq;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
    public event Action OnSoundEnd;

    public AudioSource AudioSource { get => _audioSource; }

    public AudioClip Clip
    {
        get => _clip;
        set
        {
            _clip = value;
            _lifeTime = _clip.length;

            _audioSource.clip = _clip;
        }
    }

    private AudioSource _audioSource;
    private AudioClip _clip;

    private float _lifeTime;
    private bool _isPlayOnce;

    public void PlayOnce()
    {
        _isPlayOnce = true;
        PlaySound();
    }

    public void PlaySound()
    {
        _audioSource?.Play();
    }

    /// <summary>
    /// Stops the sound playback
    /// </summary>
    /// <param name="isDestroy">Destroying the gameobject after stop.</param>
    public void StopSound(bool isDestroy = false)
    {
        _audioSource?.Stop();

        if (isDestroy)
        {
            Destroy(gameObject);
        }

        _isPlayOnce = false;
    }

    private void Update()
    {
        _lifeTime -= _isPlayOnce ? Time.deltaTime : 0;

        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnSoundEnd?.Invoke();
    }

    [Inject]
    private void Construct(Sound sound)
    {
        _audioSource = GetComponent<AudioSource>();

        Clip = sound.Clip;
        _audioSource.outputAudioMixerGroup = sound.AudioMixer;
    }

    public class Factory : PlaceholderFactory<Sound, SoundHandler> { }
}
