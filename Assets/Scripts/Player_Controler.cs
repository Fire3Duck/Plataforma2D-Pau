using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controler : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private InputAction _moveAction;
    private Vector2 _moveInput;
    private InputAction _jumpAction;
    private InputAction _attackAction;
    [SerializeField] private float _playerVelocity = 5;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>(); //Para mover el personaje.
        _moveAction = InputSystem.actions["Move"]; //Si ponemos el .FindAction usaremos los parentesis.
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        Debug.Log(_moveInput);

        //transform.position = transform.position + new Vector3(_moveInput.x, 0, 0) * _playerVelocity * Time.deltaTime;
        
        if (_jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_moveInput.x, 0) * _playerVelocity;
    }

    void Jump()
    {
        
        Debug.Log("Salto");
    }
}
