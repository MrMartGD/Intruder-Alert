using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent Activating;
    [SerializeField] private UnityEvent Deactivating;

    private AudioSource _audio;
    private bool _isActive = false;

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
        _audio.volume = Mathf.PingPong(Time.time * 0.3f, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Activating?.Invoke();
        _isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        float angle = Vector3.Angle(transform.forward, other.transform.position - transform.position);
        
        if (angle < 90)
        {
            Deactivating?.Invoke();
            _isActive = false;
        }
        else 
        {
            Activating?.Invoke();
            _isActive = true;
        }
    }
}

