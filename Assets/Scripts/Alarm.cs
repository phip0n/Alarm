using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Collider _watchedArea;
    [SerializeField] private float _maxVolume = 1;
    private int _lawbreakersCount = 0;
    private SoundPlayer _soundPlayer;

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Lawbreaker lawbreaker))
        {
            _lawbreakersCount++;
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.TryGetComponent(out Lawbreaker lawbreaker))
        {
            _lawbreakersCount--;
            Deactivate();
        }
    }

    private void Activate()
    {
        _soundPlayer.SetVolume(_maxVolume);
    }

    private void Deactivate()
    {
        if (_lawbreakersCount == 0)
            _soundPlayer.SetVolume(0);
    }
}
