using UnityEngine;
using UnityEngine.Events;

public class DogHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent Activating;
    [SerializeField] private UnityEvent Deactivating;

    private float _angleForCheckAlarm = 90f;

    private void OnTriggerEnter(Collider other)
    {
        Activating?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        float angle = Vector3.Angle(transform.forward, other.transform.position - transform.position);

        if (angle < _angleForCheckAlarm)
        {
            Deactivating?.Invoke();
        }
        else
        {
            Activating?.Invoke();
        }
    }
}
