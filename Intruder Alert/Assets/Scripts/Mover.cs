using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;

    private Rigidbody _rigidbody;
    private float _horizontalMove;
    private float _verticalMove;
    private float _angleY;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _angleY = transform.rotation.y;
    }

    private void Update()
    {
        InputValue();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputValue()
    {
        _horizontalMove = Input.GetAxis(Axis.Horizontal);
        _verticalMove = Input.GetAxis(Axis.Vertical);
        _angleY += Input.GetAxis(Axis.MouseX);
    }

    private void Move()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, _angleY * _speedRotation, 0);
        }

        _rigidbody.MovePosition(transform.position -= new Vector3(_horizontalMove, 0, _verticalMove) * _speedMove * Time.deltaTime);
    }
}