using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private float _volumeChangeTime = 0.1f;
    [SerializeField] private float _volumeChangeValue = 0.1f;
    private AudioSource _sound;
    private float _volume;
    private Coroutine _volumeChanger;
    private WaitForSeconds _changeTime;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
        _changeTime = new WaitForSeconds(_volumeChangeTime);
    }

    public void SetVolume(float volume)
    {
        _volume = volume;

        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        _volumeChanger = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        if (_volume != 0 && _sound.isPlaying == false)
            _sound.Play();

        while (_sound.volume != _volume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _volume, _volumeChangeValue);
            yield return _changeTime;
        }

        if (_sound.volume == 0)
            _sound.Stop();
    }
}
