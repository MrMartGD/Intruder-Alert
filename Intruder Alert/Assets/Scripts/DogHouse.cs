using UnityEngine;
using UnityEngine.Events;

public class DogHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent _activated;
    [SerializeField] private UnityEvent _deactivated;

    private float _angleForCheckAlarm = 90f;

    private void OnTriggerEnter(Collider other)
    {
        _activated?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        float angle = Vector3.Angle(transform.forward, other.transform.position - transform.position);

        if (angle < _angleForCheckAlarm)
        {
            _deactivated?.Invoke();
        }
        else
        {
            _activated?.Invoke();
        }
    }
}
