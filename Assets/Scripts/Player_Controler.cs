using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controler : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    //private Ground_Sensor _groundSensor;
    private InputAction _moveAction;
    private Vector2 _moveInput;
    private InputAction _jumpAction;
    private InputAction _attackAction;
    private InputAction _movingAttackAction;
    private InputAction _interactAction;
    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private float _currentHealth;

    [SerializeField] private float _playerVelocity = 5;
    [SerializeField] private float _jumpHeight = 2;
    private bool _alreadyLanded = true;

    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private Vector2 _sensorSize = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 _interactionZone = new Vector2(1,1);

    [SerializeField] private Transform _hitBoxPosition;
    [SerializeField] private float _attackRadius = 1;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _attackDamage = 10;

    //Sonido ataque
    [SerializeField] private AudioClip _atackAudio;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>(); //Para mover el personaje.
        //_groundSensor = GetComponentInChildren<Ground_Sensor>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"]; //Si ponemos el .FindAction usaremos los parentesis.
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
        _interactAction = InputSystem.actions["Interact"];
        _movingAttackAction = InputSystem.actions["MoveAttack"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
        //_healthBar.fillAmount = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        Debug.Log(_moveInput);

        //transform.position = transform.position + new Vector3(_moveInput.x, 0, 0) * _playerVelocity * Time.deltaTime;

        if (_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }

        if (_interactAction.WasPerformedThisFrame())
        {
            Interact();
        }

        Movement();

        _animator.SetBool("IsJumping", !IsGrounded());

        if (_attackAction.WasPerformedThisFrame())
        {
            Attack();
        }

        if (_movingAttackAction.WasPerformedThisFrame())
        {
            MoveAttack();
        }
        
    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_moveInput.x * _playerVelocity, _rigidBody.linearVelocity.y);
    }

    void Movement()
    {
        if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsMoving", true);
        }

        else if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsMoving", true);
        }

        else
        {
            _animator.SetBool("IsMoving", false);
        }

    }
    void Jump()
    {
        _rigidBody.AddForce(transform.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
        Debug.Log("Salto");

    }

    void Interact()
    {
        //Debug.Log("Haciendo cosas");
        Collider2D[] interactables = Physics2D.OverlapBoxAll(transform.position, _interactionZone, 0);
        foreach (Collider2D item in interactables)
        {
            if (item.gameObject.tag == "Star")
            {
                Star starscript = item.gameObject.GetComponent<Star>();

                if (starscript != null)
                {
                    starscript.Interaction();
                }

                
            }
        }
    }

    void Attack()
    {
        _animator.SetTrigger("IsAttacking");
        Debug.Log("Attack");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius, _enemyLayer);
         _audioSource.PlayOneShot(_atackAudio); 
         foreach(Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(_attackDamage);
        }   

        
    }

    void MoveAttack()
    {
        _animator.SetTrigger("IsMoveAttacking");
        Debug.Log("MoveAttack");
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        GUI_manager.Instance.UpdateHealthBar(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Muerto");
    }

    bool IsGrounded()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(_sensorPosition.position, _sensorSize, 0);
        foreach (Collider2D item in ground)
        {
            if (item.gameObject.layer == 3)
            {
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_sensorPosition.position, _sensorSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _interactionZone);
    
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(_hitBoxPosition.position, _attackRadius);
    }
}
