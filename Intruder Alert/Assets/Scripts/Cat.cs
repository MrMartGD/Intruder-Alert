using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cat : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;
    
    private Rigidbody _rigidbody;
    private float _horizontalMove;
    private float _verticalMove;
    private float _angleY;
    
    private void Start()
    {
        _angleY = transform.rotation.y;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputValue();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(1)) 
        {
            transform.Rotate(0, _angleY * _speedRotation, 0);
        }
        
        _rigidbody.MovePosition(transform.position += new Vector3(_horizontalMove, 0, _verticalMove) * _speedMove * Time.deltaTime * -1);
    }

    private void InputValue() 
    {
        _horizontalMove = Input.GetAxis(Axis.Horizontal);
        _verticalMove = Input.GetAxis(Axis.Vertical);
        _angleY += Input.GetAxis(Axis.MouseX);
    }
}
