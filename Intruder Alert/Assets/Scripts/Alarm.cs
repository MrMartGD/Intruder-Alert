using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange = 0.3f;
    
    private AudioSource _audio;
    private float _VolumeMax = 1f;
    private bool _isActive = false;
    
    public void TurnOn() 
    {
        _audio.Play();
        _isActive = true;
    }

    public void TurnOff() 
    {
        _audio.Stop();
        _isActive = false;
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isActive) 
        {
             ChangeVolume();
        }
    }

    private void ChangeVolume() 
    {
        _audio.volume = Mathf.PingPong(Time.time * _speedVolumeChange, _VolumeMax);
    }
}