using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private float _maxVolumeValue = 1.0f;
    private float _minVolumeValue = 0f;
    private float _volumeChangeSpeed = 0.5f;

    private Coroutine _changeVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolumeValue;
    }

    public void Play()
    {
        _audioSource.Play();

        SetValue(_maxVolumeValue);
    }

    public void Stop()
    {
        SetValue(_minVolumeValue);

        if (_audioSource.volume == _minVolumeValue)
        {
            _audioSource.Stop();
        }
    }

    private void SetValue(float targetValue)
    {
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }

        _changeVolume = StartCoroutine(ChangeVolume(targetValue));
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        while (_audioSource.volume != targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
